namespace A32TAK
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            rtbLogs = new RichTextBox();
            lblTargetIP = new Label();
            tbTargetIPAddresss = new TextBox();
            btnSetTarget = new Button();
            tbTargetPort = new TextBox();
            tbLatitudeBand = new TextBox();
            tbGridSquare1 = new TextBox();
            tbGridSquare2 = new TextBox();
            lblMGRSDesc = new Label();
            tbUTMZone = new TextBox();
            msMain = new MenuStrip();
            tsmFile = new ToolStripMenuItem();
            tsmClose = new ToolStripMenuItem();
            tsmProfiles = new ToolStripMenuItem();
            tsmAbout = new ToolStripMenuItem();
            lblActivity = new Label();
            lblActivityL = new Label();
            tbGeoidHeight = new TextBox();
            msMain.SuspendLayout();
            SuspendLayout();
            // 
            // rtbLogs
            // 
            rtbLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbLogs.BackColor = Color.Black;
            rtbLogs.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbLogs.ForeColor = Color.White;
            rtbLogs.Location = new Point(12, 171);
            rtbLogs.Name = "rtbLogs";
            rtbLogs.ReadOnly = true;
            rtbLogs.Size = new Size(627, 275);
            rtbLogs.TabIndex = 0;
            rtbLogs.Text = "";
            // 
            // lblTargetIP
            // 
            lblTargetIP.AutoSize = true;
            lblTargetIP.FlatStyle = FlatStyle.System;
            lblTargetIP.Location = new Point(12, 35);
            lblTargetIP.Name = "lblTargetIP";
            lblTargetIP.Size = new Size(103, 15);
            lblTargetIP.TabIndex = 3;
            lblTargetIP.Text = "Target TAK IP, Port";
            // 
            // tbTargetIPAddresss
            // 
            tbTargetIPAddresss.Location = new Point(12, 53);
            tbTargetIPAddresss.Name = "tbTargetIPAddresss";
            tbTargetIPAddresss.Size = new Size(98, 23);
            tbTargetIPAddresss.TabIndex = 4;
            tbTargetIPAddresss.Text = "127.0.0.1";
            // 
            // btnSetTarget
            // 
            btnSetTarget.FlatStyle = FlatStyle.System;
            btnSetTarget.Location = new Point(10, 131);
            btnSetTarget.Name = "btnSetTarget";
            btnSetTarget.Size = new Size(48, 23);
            btnSetTarget.TabIndex = 5;
            btnSetTarget.Text = "Set";
            btnSetTarget.UseVisualStyleBackColor = true;
            btnSetTarget.Click += btnSetTarget_Click;
            // 
            // tbTargetPort
            // 
            tbTargetPort.Location = new Point(116, 53);
            tbTargetPort.Name = "tbTargetPort";
            tbTargetPort.Size = new Size(46, 23);
            tbTargetPort.TabIndex = 6;
            tbTargetPort.Text = "4349";
            // 
            // tbLatitudeBand
            // 
            tbLatitudeBand.Location = new Point(64, 97);
            tbLatitudeBand.Name = "tbLatitudeBand";
            tbLatitudeBand.Size = new Size(46, 23);
            tbLatitudeBand.TabIndex = 7;
            // 
            // tbGridSquare1
            // 
            tbGridSquare1.Location = new Point(116, 97);
            tbGridSquare1.Name = "tbGridSquare1";
            tbGridSquare1.Size = new Size(46, 23);
            tbGridSquare1.TabIndex = 8;
            // 
            // tbGridSquare2
            // 
            tbGridSquare2.Location = new Point(168, 97);
            tbGridSquare2.Name = "tbGridSquare2";
            tbGridSquare2.Size = new Size(46, 23);
            tbGridSquare2.TabIndex = 9;
            // 
            // lblMGRSDesc
            // 
            lblMGRSDesc.AutoSize = true;
            lblMGRSDesc.FlatStyle = FlatStyle.System;
            lblMGRSDesc.Location = new Point(12, 79);
            lblMGRSDesc.Name = "lblMGRSDesc";
            lblMGRSDesc.Size = new Size(402, 15);
            lblMGRSDesc.TabIndex = 10;
            lblMGRSDesc.Text = "UTM Zone, Latitude Band, Grid Square 1, Grid Square 2             Geoid Height";
            // 
            // tbUTMZone
            // 
            tbUTMZone.Location = new Point(12, 97);
            tbUTMZone.Name = "tbUTMZone";
            tbUTMZone.Size = new Size(46, 23);
            tbUTMZone.TabIndex = 11;
            // 
            // msMain
            // 
            msMain.Items.AddRange(new ToolStripItem[] { tsmFile, tsmProfiles, tsmAbout });
            msMain.Location = new Point(0, 0);
            msMain.Name = "msMain";
            msMain.Size = new Size(651, 24);
            msMain.TabIndex = 12;
            msMain.Text = "msMain";
            // 
            // tsmFile
            // 
            tsmFile.DropDownItems.AddRange(new ToolStripItem[] { tsmClose });
            tsmFile.Name = "tsmFile";
            tsmFile.Size = new Size(37, 20);
            tsmFile.Text = "File";
            // 
            // tsmClose
            // 
            tsmClose.Name = "tsmClose";
            tsmClose.Size = new Size(103, 22);
            tsmClose.Text = "Close";
            tsmClose.Click += tsmClose_Click;
            // 
            // tsmProfiles
            // 
            tsmProfiles.Name = "tsmProfiles";
            tsmProfiles.Size = new Size(58, 20);
            tsmProfiles.Text = "Profiles";
            // 
            // tsmAbout
            // 
            tsmAbout.Name = "tsmAbout";
            tsmAbout.Size = new Size(52, 20);
            tsmAbout.Text = "About";
            tsmAbout.Click += tsmAbout_Click;
            // 
            // lblActivity
            // 
            lblActivity.AutoSize = true;
            lblActivity.FlatStyle = FlatStyle.System;
            lblActivity.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblActivity.ForeColor = Color.Gray;
            lblActivity.Location = new Point(197, 106);
            lblActivity.Name = "lblActivity";
            lblActivity.Size = new Size(48, 65);
            lblActivity.TabIndex = 13;
            lblActivity.Text = "•";
            // 
            // lblActivityL
            // 
            lblActivityL.AutoSize = true;
            lblActivityL.FlatStyle = FlatStyle.System;
            lblActivityL.Location = new Point(141, 135);
            lblActivityL.Name = "lblActivityL";
            lblActivityL.Size = new Size(50, 15);
            lblActivityL.TabIndex = 14;
            lblActivityL.Text = "Activity:";
            // 
            // tbGeoidHeight
            // 
            tbGeoidHeight.Location = new Point(336, 97);
            tbGeoidHeight.Name = "tbGeoidHeight";
            tbGeoidHeight.Size = new Size(46, 23);
            tbGeoidHeight.TabIndex = 15;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 458);
            Controls.Add(tbGeoidHeight);
            Controls.Add(lblActivityL);
            Controls.Add(tbUTMZone);
            Controls.Add(lblMGRSDesc);
            Controls.Add(tbGridSquare2);
            Controls.Add(tbGridSquare1);
            Controls.Add(tbLatitudeBand);
            Controls.Add(tbTargetPort);
            Controls.Add(btnSetTarget);
            Controls.Add(tbTargetIPAddresss);
            Controls.Add(lblTargetIP);
            Controls.Add(rtbLogs);
            Controls.Add(msMain);
            Controls.Add(lblActivity);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = msMain;
            MinimumSize = new Size(500, 300);
            Name = "MainWindow";
            Text = "A32TAK";
            Load += MainWindow_Load;
            msMain.ResumeLayout(false);
            msMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public RichTextBox rtbLogs;
        private Label lblTargetIP;
        private TextBox tbTargetIPAddresss;
        private Button btnSetTarget;
        private TextBox tbTargetPort;
        private TextBox tbLatitudeBand;
        private TextBox tbGridSquare1;
        private TextBox tbGridSquare2;
        private Label lblMGRSDesc;
        private TextBox tbUTMZone;
        private MenuStrip msMain;
        private ToolStripMenuItem tsmFile;
        private ToolStripMenuItem tsmClose;
        private ToolStripMenuItem tsmProfiles;
        private ToolStripMenuItem tsmAbout;
        private Label lblActivity;
        private Label lblActivityL;
        private TextBox tbGeoidHeight;
    }
}