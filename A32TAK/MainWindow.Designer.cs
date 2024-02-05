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
            rtbLogs = new RichTextBox();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            lblTargetIP = new Label();
            tbTargetIPAddresss = new TextBox();
            btnSetTarget = new Button();
            tbNMEA = new TextBox();
            label1 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // rtbLogs
            // 
            rtbLogs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtbLogs.BackColor = Color.Black;
            rtbLogs.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbLogs.ForeColor = Color.White;
            rtbLogs.Location = new Point(12, 131);
            rtbLogs.Name = "rtbLogs";
            rtbLogs.ReadOnly = true;
            rtbLogs.Size = new Size(694, 280);
            rtbLogs.TabIndex = 0;
            rtbLogs.Text = "";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(718, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(103, 22);
            closeToolStripMenuItem.Text = "Close";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 425);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(718, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblTargetIP
            // 
            lblTargetIP.AutoSize = true;
            lblTargetIP.Location = new Point(12, 45);
            lblTargetIP.Name = "lblTargetIP";
            lblTargetIP.Size = new Size(124, 15);
            lblTargetIP.TabIndex = 3;
            lblTargetIP.Text = "Target ATAK (IP:PORT):";
            // 
            // tbTargetIPAddresss
            // 
            tbTargetIPAddresss.Location = new Point(148, 42);
            tbTargetIPAddresss.Name = "tbTargetIPAddresss";
            tbTargetIPAddresss.Size = new Size(171, 23);
            tbTargetIPAddresss.TabIndex = 4;
            // 
            // btnSetTarget
            // 
            btnSetTarget.Location = new Point(325, 42);
            btnSetTarget.Name = "btnSetTarget";
            btnSetTarget.Size = new Size(75, 23);
            btnSetTarget.TabIndex = 5;
            btnSetTarget.Text = "Set";
            btnSetTarget.UseVisualStyleBackColor = true;
            btnSetTarget.Click += btnSetTarget_Click;
            // 
            // tbNMEA
            // 
            tbNMEA.Location = new Point(166, 87);
            tbNMEA.Name = "tbNMEA";
            tbNMEA.Size = new Size(362, 23);
            tbNMEA.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 95);
            label1.Name = "label1";
            label1.Size = new Size(106, 15);
            label1.TabIndex = 7;
            label1.Text = "kevins nmea string";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 447);
            Controls.Add(label1);
            Controls.Add(tbNMEA);
            Controls.Add(btnSetTarget);
            Controls.Add(tbTargetIPAddresss);
            Controls.Add(lblTargetIP);
            Controls.Add(statusStrip1);
            Controls.Add(rtbLogs);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(500, 300);
            Name = "MainWindow";
            Text = "A32TAK";
            Load += MainWindow_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public RichTextBox rtbLogs;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private StatusStrip statusStrip1;
        private Label lblTargetIP;
        private TextBox tbTargetIPAddresss;
        private Button btnSetTarget;
        public TextBox tbNMEA;
        private Label label1;
    }
}