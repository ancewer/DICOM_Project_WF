using EvilDICOM.Core;
using EvilDICOM.Core.Helpers;
using EvilDICOM.Network;
using EvilDICOM.Network.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVH_Project_WF
{
    public class DICOMTransfer
    {
        Entity daemon = null;
        Entity local = null;
        DICOMSCU client = null;
        DICOMSCP receiver = null;
        ////TextBox tb_Info = null;

        public bool DICOMConnection(string AE_Server, string AE_Client)
        {
            //Store the details of the daemon (Ae Title, IP, port)
            daemon = new Entity(AE_Server.Split(',')[0], AE_Server.Split(',')[1], int.Parse(AE_Server.Split(',')[2]));
            //Store the details of the client (Ae Title, port) -> IP address is determined by CreateLocal() method
            local = Entity.CreateLocal(AE_Client.Split(',')[0], int.Parse(AE_Client.Split(',')[2]));
            //Set up a client (DICOM SCU = Service Class User)
            client = new DICOMSCU(local);
            receiver = new DICOMSCP(local);

            //TRY C-/*ECHO*/
            var canPing = client.Ping(daemon);
            if (canPing == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ChangeCBCTNames(string folder)
        {

            var studyfolders = Directory.GetDirectories(folder);
            foreach (var studyfolder in studyfolders)
            {
                var CBCTfolder = Path.Combine(studyfolder, "CBCT");
                Directory.CreateDirectory(CBCTfolder);
                Console.WriteLine("Change CBCT file names...");
                var files = Directory.GetFiles(studyfolder);
                foreach (var file in files)
                {
                    if (file.Contains(".dcm") & file.Contains("CT."))
                    {
                        var dcm = EvilDICOM.Core.DICOMObject.Read(file);
                        var temp = dcm.GetSelector().ManufacturerModelName.Data;
                        if (temp.Contains("OBI") | temp.Contains("Cone-beam CT"))
                        {
                            Directory.Move(file, file.Replace("CT.",  "\\CBCT\\CBCT."));
                        }
                    }
                }
            }

        }

        public static void DeleteDirectory(string target_dir)
        {
            string[] files = Directory.GetFiles(target_dir);
            string[] dirs = Directory.GetDirectories(target_dir);

            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }
            Directory.Delete(target_dir, false);
        }

        public void ExportDICOMFiles(string patientID, string outputdir, bool keepCBCT=false)
        {
            //Set up a receiver to catch the files as they come in
            //Let the daemon know we can take anything it sends
            receiver.SupportedAbstractSyntaxes = AbstractSyntax.ALL_RADIOTHERAPY_STORAGE;
            //Set up storage location
            //Set the action when a DICOM files comes in
            receiver.DIMSEService.CStoreService.CStorePayloadAction = (dcm, asc) =>
            {
                var temp = dcm.GetSelector().ManufacturerModelName.Data;
                if (keepCBCT==false & (temp.Contains("OBI") | temp.Contains("Cone-beam CT"))) 
                {
                    return true; // Lets daemom know if you successfully wrote to drive
                }
                else
                {
                    var studyfolder = Path.Combine(outputdir, "Study_" + dcm.GetSelector().StudyID.Data);
                    Directory.CreateDirectory(studyfolder);
                    var path = Path.Combine(studyfolder, dcm.GetSelector().Modality.Data + "." + dcm.GetSelector().SOPInstanceUID.Data + ".dcm");
                    //Console.WriteLine($"Writing file {path}...");
                    dcm.Write(path);
                    return true; // Lets daemom know if you successfully wrote to drive
                }
            };
            receiver.ListenForIncomingAssociations(true);
            var mover = client.GetCMover(daemon);

            //Build a finder class to help with C-FIND operations
            var finder = client.GetCFinder(daemon);
            var studies = finder.FindStudies(patientID);
            var series = finder.FindSeries(studies);
            //Filter series by modality, then create list of 
            List<string> ModalityList = new List<string>() { "RTPLAN", "RTDOSE", "RTSTRUCT", /*"RTRECORD",*/ "CT", "MR", "PT", "REG" };
            var allitems = series.Where(s => ModalityList.Contains(s.Modality)).SelectMany(ser => finder.FindImages(ser)).ToList();
            ushort msgId = 1;
            //var allitems = plans.Union(doses).ToList().Union(cts).ToList().Union(rts).ToList();
            for(int j=0;j<allitems.Count(); j++)
            {
                //Console.WriteLine($"[{i}/{nums}] Sending plan {plan.SOPInstanceUID}...");
                //Make sure Mobius is on the whitelist of the daemon
                var response = mover.SendCMove(allitems[j], local.AeTitle, ref msgId);
                //Console.WriteLine($"DICOM C-Move Results : ");
                //Console.WriteLine($"Number of Completed Operations : {response.NumberOfCompletedOps}");
                //Console.WriteLine($"Number of Failed Operations : {response.NumberOfFailedOps}");
                //Console.WriteLine($"Number of Remaining Operations : {response.NumberOfRemainingOps}");
                //Console.WriteLine($"Number of Warning Operations : {response.NumberOfWarningOps}");
            }
            
        }

        public void ImportDICOMFiles(string patientID, string importdir)
        {
            var storer = client.GetCStorer(daemon);
            var storagePath = Path.Combine(importdir, patientID);

            ushort msgId = 1;
            var dcmFiles = Directory.GetFiles(storagePath);
            foreach (var dcmfile in dcmFiles)
            {
                //Reads DICOM object into memory
                var dcm = DICOMObject.Read(dcmfile);
                var response = storer.SendCStore(dcm, ref msgId);
                //Write results to console
                Console.WriteLine($"DICOM C-Store from {local.AeTitle} => " +
                        $"{daemon.AeTitle} @{daemon.IpAddress}:{daemon.Port}:" +
                        $"{(Status)response.Status}");
            }
        }
        public void ExportSingleCT(string patientID, string outputdir)
        {
            //Set up a receiver to catch the files as they come in
            //Let the daemon know we can take anything it sends
            receiver.SupportedAbstractSyntaxes = AbstractSyntax.ALL_RADIOTHERAPY_STORAGE;
            //Set up storage location
            //Set the action when a DICOM files comes in
            receiver.DIMSEService.CStoreService.CStorePayloadAction = (dcm, asc) =>
            {
                //var temp = dcm.GetSelector().ManufacturerModelName.Data;
                var path = Path.Combine(outputdir, dcm.GetSelector().Modality.Data + "." + dcm.GetSelector().SOPInstanceUID.Data + ".dcm");
                //Console.WriteLine($"Writing file {path}...");
                dcm.Write(path);
                return true; // Lets daemom know if you successfully wrote to drive
            };
            receiver.ListenForIncomingAssociations(true);
            var mover = client.GetCMover(daemon);

            //Build a finder class to help with C-FIND operations
            var finder = client.GetCFinder(daemon);
            var studies = finder.FindStudies(patientID);
            if (studies.LongCount() == 0)
            {
                Console.WriteLine($"No Study found for {patientID}");
                return;
            }
            var series = finder.FindSeries(studies.FirstOrDefault());
            if (series.LongCount() == 0)
            {
                Console.WriteLine($"No Series found for {patientID}");
                return;
            }
            //Filter series by modality, then create list of 
            List<string> ModalityList = new List<string>() {"CT"};
            var allitems = series.Where(s => ModalityList.Contains(s.Modality)).SelectMany(ser => finder.FindImages(ser)).ToList();
            if (allitems.Count() < 1)
            {
                Console.WriteLine($"No CT found for {patientID}");
                return;
            }
            allitems = new List<EvilDICOM.Network.DIMSE.IOD.CFindInstanceIOD> { allitems[0] };
            ushort msgId = 1;
            var response = mover.SendCMove(allitems[0], local.AeTitle, ref msgId);
        }

        public static void ExportCTExamFlag(string folder)
        {
            var fname = Path.Combine(folder, "_Sites.csv");
            System.IO.StreamWriter swFile = new System.IO.StreamWriter(fname);

            var files = Directory.GetFiles(folder, "*.dcm");
            swFile.WriteLine($"# number of patients: {files.Length}");
            swFile.WriteLine("# PatientID,BodyPartExamined,StudyDescription");

            for (int i = 0; i < files.Length; i++)
            {

                var dcm = DICOMObject.Read(files[i]).GetSelector();
                Console.WriteLine($"[{i}/{files.Length}] processing patient {dcm.PatientID.Data}...");

                try
                {
                    swFile.WriteLine($"{dcm.PatientID.Data},{dcm.BodyPartExamined.Data},{dcm.StudyDescription.Data}");
                }
                catch
                {
                    swFile.WriteLine($"{dcm.PatientID.Data},null,null");
                }
            }
            swFile.Close();
        }
    }
}
