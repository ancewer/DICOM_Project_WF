using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using VMS.TPS.Common.Model.API;

using EvilDICOM.Anonymization.Anonymizers;
using EvilDICOM.Core.Modules;
using EvilDICOM.Core.Helpers;
using EvilDICOM.Network;
using EvilDICOM.Core.IO.Data;

using IniParser;
using IniParser.Model;
//using Patient = VMS.TPS.Common.Model.API.Patient;


namespace DVH_Project_WF
{
    public partial class MyWindow : Form
    {

        //ManualResetEvent TaskOnOff = new ManualResetEvent(true);
        public IniData config = null;
        public VMS.TPS.Common.Model.API.Application app = null;
        public DICOMTransfer dicom_transfer = new DICOMTransfer();
        public MyWindow()
        {
            app = VMS.TPS.Common.Model.API.Application.CreateApplication();
            var parser = new FileIniDataParser();
            config = parser.ReadFile("config.ini");
            InitializeComponent();
            Console.SetOut(new ConsoleTextWriter(this.textBox_Info));
            LoadConfigIni(config);
        }


        private void button_Echo_Click(object sender, EventArgs e)
        {
            this.button_Echo.BackColor = Color.White;
            this.textBox_Info.Clear();

            bool flag = dicom_transfer.DICOMConnection(this.textBox_AriaDB_AE.Text, this.textBox_Trusted_AE.Text);
            if (flag == true)
            {
                this.button_Echo.BackColor = Color.Green;
                Console.WriteLine("connection success!");
            }
            else
            {
                this.button_Echo.BackColor = Color.Red;
                Console.WriteLine("connection failed!");
            }
        }



        private void LoadConfigIni(IniData config)
        {
            this.textBox_AriaDB_AE.Text = $"{config["AriaDB_AE"]["title"]},{config["AriaDB_AE"]["ip"]},{config["AriaDB_AE"]["port"]}";
            this.textBox_Trusted_AE.Text = $"{config["Trusted_AE"]["title"]},{config["Trusted_AE"]["ip"]},{config["Trusted_AE"]["port"]}";

        }

        private void button_DICOMImport_Click(object sender, EventArgs e)
        {
            this.progressBar1.Value = 0;
            if (this.button_Echo.BackColor != Color.Green)
            {
                MessageBox.Show("Please echo first and make sure the connection success!");
                return;
            }
            var patientdirs = Directory.GetDirectories(this.textBox_DICOMImportdir.Text);
            for (int i = 0; i < patientdirs.Length; i++)
            {
                var patientID = patientdirs[i].Substring(patientdirs[i].LastIndexOf('\\') + 1);
                Console.WriteLine($"importing DICOM files for {patientID} starting......");
                string folder = Path.Combine(this.textBox_DICOMOutputdir.Text, patientID);
                Directory.CreateDirectory(folder);
                var task_1 = new Task(() => dicom_transfer.ImportDICOMFiles(patientdirs[i], folder));
                task_1.Start();
                task_1.Wait();
                this.progressBar1.Value = 100 * (i + 1) / patientdirs.Length;
                Console.WriteLine($"importing DICOM files for {patientID} finished!");
            }
            this.progressBar1.Value = 100;
            MessageBox.Show("All tasks finished!");
        }

        private void button_DICOMExport_Click(object sender, EventArgs e)
        {
            this.progressBar1.Value = 0;


            if (this.button_Echo.BackColor != Color.Green)
            {
                MessageBox.Show("Please echo first and make sure the connection success!");
                return;
            }
            if (this.checkBox_DICOMFilterByPatientID.Checked == true)
            {
                var patientIDs = this.textBox_ExportByPatientID.Text.Split(',');

                for (int i = 0; i < patientIDs.Length; i++)
                {

                    var patientID = patientIDs[i].Trim();
                    Console.WriteLine($"exporting DICOM files for {patientID} starting......");

                    string folder = Path.Combine(this.textBox_DICOMOutputdir.Text.Trim(), patientID);
                    if (Directory.Exists(folder))
                    {
                        DICOMTransfer.DeleteDirectory(folder);
                    }
                    Directory.CreateDirectory(folder);
                    var task_1 = new Task(() => dicom_transfer.ExportDICOMFiles(patientIDs[i], folder, this.checkBox_KeepCBCT.Checked));
                    task_1.Start();
                    task_1.Wait();
                    if(this.checkBox_KeepCBCT.Checked)
                        dicom_transfer.ChangeCBCTNames(folder);
                    this.progressBar1.Value = 100 * (i + 1) / patientIDs.Length;
                    Console.WriteLine($"exporting DICOM files for {patientID} finished!");
                }
            }
            MessageBox.Show("All tasks finished!");
        }
    }
}
