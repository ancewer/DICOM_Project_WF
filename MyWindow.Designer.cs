using System;

namespace DVH_Project_WF
{
    partial class MyWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Info = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Developing = new System.Windows.Forms.TabPage();
            this.DICOM = new System.Windows.Forms.TabPage();
            this.button_Echo = new System.Windows.Forms.Button();
            this.textBox_Trusted_AE = new System.Windows.Forms.TextBox();
            this.textBox_AriaDB_AE = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox_KeepCBCT = new System.Windows.Forms.CheckBox();
            this.textBox_ExportByPatientID = new System.Windows.Forms.TextBox();
            this.checkBox_DICOMFilterByPatientID = new System.Windows.Forms.CheckBox();
            this.textBox_DICOMOutputdir = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button_DICOMExport = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_DICOMImport = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_DICOMImportdir = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.DICOM.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Info
            // 
            this.textBox_Info.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Info.Location = new System.Drawing.Point(746, 49);
            this.textBox_Info.Multiline = true;
            this.textBox_Info.Name = "textBox_Info";
            this.textBox_Info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_Info.Size = new System.Drawing.Size(302, 465);
            this.textBox_Info.TabIndex = 1;
            this.textBox_Info.Text = "this is output box";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1048, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "status1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel2.Text = "status2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1048, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(56, 20);
            this.toolStripMenuItem2.Text = "Setting";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Violet;
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBar1.Location = new System.Drawing.Point(9, 499);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(726, 17);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.UseWaitCursor = true;
            // 
            // Developing
            // 
            this.Developing.Location = new System.Drawing.Point(4, 22);
            this.Developing.Name = "Developing";
            this.Developing.Padding = new System.Windows.Forms.Padding(3);
            this.Developing.Size = new System.Drawing.Size(734, 444);
            this.Developing.TabIndex = 1;
            this.Developing.Text = "Developing";
            this.Developing.UseVisualStyleBackColor = true;
            // 
            // DICOM
            // 
            this.DICOM.Controls.Add(this.button_Echo);
            this.DICOM.Controls.Add(this.textBox_Trusted_AE);
            this.DICOM.Controls.Add(this.textBox_AriaDB_AE);
            this.DICOM.Controls.Add(this.label8);
            this.DICOM.Controls.Add(this.label7);
            this.DICOM.Controls.Add(this.groupBox5);
            this.DICOM.Controls.Add(this.groupBox4);
            this.DICOM.Location = new System.Drawing.Point(4, 22);
            this.DICOM.Name = "DICOM";
            this.DICOM.Size = new System.Drawing.Size(734, 444);
            this.DICOM.TabIndex = 2;
            this.DICOM.Text = "DICOM Import/Export";
            this.DICOM.UseVisualStyleBackColor = true;
            // 
            // button_Echo
            // 
            this.button_Echo.Location = new System.Drawing.Point(575, 32);
            this.button_Echo.Name = "button_Echo";
            this.button_Echo.Size = new System.Drawing.Size(61, 23);
            this.button_Echo.TabIndex = 5;
            this.button_Echo.Text = "Echo";
            this.button_Echo.UseVisualStyleBackColor = true;
            this.button_Echo.Click += new System.EventHandler(this.button_Echo_Click);
            // 
            // textBox_Trusted_AE
            // 
            this.textBox_Trusted_AE.Location = new System.Drawing.Point(294, 48);
            this.textBox_Trusted_AE.Name = "textBox_Trusted_AE";
            this.textBox_Trusted_AE.Size = new System.Drawing.Size(223, 20);
            this.textBox_Trusted_AE.TabIndex = 4;
            // 
            // textBox_AriaDB_AE
            // 
            this.textBox_AriaDB_AE.Location = new System.Drawing.Point(294, 20);
            this.textBox_AriaDB_AE.Name = "textBox_AriaDB_AE";
            this.textBox_AriaDB_AE.Size = new System.Drawing.Size(223, 20);
            this.textBox_AriaDB_AE.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(164, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Trusted AE Title/IP/Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(121, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Aria DB Daemon AE Title/IP/Port";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox_KeepCBCT);
            this.groupBox5.Controls.Add(this.textBox_ExportByPatientID);
            this.groupBox5.Controls.Add(this.checkBox_DICOMFilterByPatientID);
            this.groupBox5.Controls.Add(this.textBox_DICOMOutputdir);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.button_DICOMExport);
            this.groupBox5.Location = new System.Drawing.Point(345, 82);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(291, 262);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Export to Local";
            // 
            // checkBox_KeepCBCT
            // 
            this.checkBox_KeepCBCT.AutoSize = true;
            this.checkBox_KeepCBCT.Location = new System.Drawing.Point(17, 94);
            this.checkBox_KeepCBCT.Name = "checkBox_KeepCBCT";
            this.checkBox_KeepCBCT.Size = new System.Drawing.Size(82, 17);
            this.checkBox_KeepCBCT.TabIndex = 10;
            this.checkBox_KeepCBCT.Text = "Keep CBCT";
            this.checkBox_KeepCBCT.UseVisualStyleBackColor = true;
            // 
            // textBox_ExportByPatientID
            // 
            this.textBox_ExportByPatientID.Location = new System.Drawing.Point(111, 58);
            this.textBox_ExportByPatientID.Multiline = true;
            this.textBox_ExportByPatientID.Name = "textBox_ExportByPatientID";
            this.textBox_ExportByPatientID.Size = new System.Drawing.Size(152, 20);
            this.textBox_ExportByPatientID.TabIndex = 9;
            this.textBox_ExportByPatientID.Text = "000,111";
            // 
            // checkBox_DICOMFilterByPatientID
            // 
            this.checkBox_DICOMFilterByPatientID.AutoSize = true;
            this.checkBox_DICOMFilterByPatientID.Checked = true;
            this.checkBox_DICOMFilterByPatientID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_DICOMFilterByPatientID.Location = new System.Drawing.Point(17, 61);
            this.checkBox_DICOMFilterByPatientID.Name = "checkBox_DICOMFilterByPatientID";
            this.checkBox_DICOMFilterByPatientID.Size = new System.Drawing.Size(85, 17);
            this.checkBox_DICOMFilterByPatientID.TabIndex = 8;
            this.checkBox_DICOMFilterByPatientID.Text = "By PatientID";
            this.checkBox_DICOMFilterByPatientID.UseVisualStyleBackColor = true;
            // 
            // textBox_DICOMOutputdir
            // 
            this.textBox_DICOMOutputdir.Location = new System.Drawing.Point(111, 26);
            this.textBox_DICOMOutputdir.Name = "textBox_DICOMOutputdir";
            this.textBox_DICOMOutputdir.Size = new System.Drawing.Size(152, 20);
            this.textBox_DICOMOutputdir.TabIndex = 7;
            this.textBox_DICOMOutputdir.Text = "D:\\DICOM Storage\\Export";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "Local DICOM Folder";
            // 
            // button_DICOMExport
            // 
            this.button_DICOMExport.Location = new System.Drawing.Point(102, 233);
            this.button_DICOMExport.Name = "button_DICOMExport";
            this.button_DICOMExport.Size = new System.Drawing.Size(84, 23);
            this.button_DICOMExport.TabIndex = 7;
            this.button_DICOMExport.Text = "Export DICOM";
            this.button_DICOMExport.UseVisualStyleBackColor = true;
            this.button_DICOMExport.Click += new System.EventHandler(this.button_DICOMExport_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_DICOMImport);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.textBox_DICOMImportdir);
            this.groupBox4.Location = new System.Drawing.Point(8, 82);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(278, 262);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Import to AriaDB";
            // 
            // button_DICOMImport
            // 
            this.button_DICOMImport.Location = new System.Drawing.Point(98, 233);
            this.button_DICOMImport.Name = "button_DICOMImport";
            this.button_DICOMImport.Size = new System.Drawing.Size(67, 23);
            this.button_DICOMImport.TabIndex = 6;
            this.button_DICOMImport.Text = "Import";
            this.button_DICOMImport.UseVisualStyleBackColor = true;
            this.button_DICOMImport.Click += new System.EventHandler(this.button_DICOMImport_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Local DICOM Folder";
            // 
            // textBox_DICOMImportdir
            // 
            this.textBox_DICOMImportdir.Location = new System.Drawing.Point(114, 24);
            this.textBox_DICOMImportdir.Name = "textBox_DICOMImportdir";
            this.textBox_DICOMImportdir.Size = new System.Drawing.Size(152, 20);
            this.textBox_DICOMImportdir.TabIndex = 0;
            this.textBox_DICOMImportdir.Text = "D:\\DICOM Storage\\Import";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.DICOM);
            this.tabControl1.Controls.Add(this.Developing);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tabControl1.Location = new System.Drawing.Point(0, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(742, 470);
            this.tabControl1.TabIndex = 7;
            // 
            // MyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Ivory;
            this.ClientSize = new System.Drawing.Size(1048, 539);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox_Info);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MyWindow";
            this.Text = "Eclipse Scripting";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.DICOM.ResumeLayout(false);
            this.DICOM.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox_Info;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabPage Developing;
        private System.Windows.Forms.TabPage DICOM;
        private System.Windows.Forms.Button button_Echo;
        private System.Windows.Forms.TextBox textBox_Trusted_AE;
        private System.Windows.Forms.TextBox textBox_AriaDB_AE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox_KeepCBCT;
        private System.Windows.Forms.TextBox textBox_ExportByPatientID;
        private System.Windows.Forms.CheckBox checkBox_DICOMFilterByPatientID;
        private System.Windows.Forms.TextBox textBox_DICOMOutputdir;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_DICOMExport;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_DICOMImport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_DICOMImportdir;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

