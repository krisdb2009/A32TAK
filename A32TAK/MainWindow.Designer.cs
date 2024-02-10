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
            lblTargetIP = new Label();
            tbTargetIPAddresss = new TextBox();
            btnSetTarget = new Button();
            textBox1 = new TextBox();
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
            rtbLogs.Size = new Size(627, 257);
            rtbLogs.TabIndex = 0;
            rtbLogs.Text = "";
            // 
            // lblTargetIP
            // 
            lblTargetIP.AutoSize = true;
            lblTargetIP.FlatStyle = FlatStyle.System;
            lblTargetIP.Location = new Point(12, 19);
            lblTargetIP.Name = "lblTargetIP";
            lblTargetIP.Size = new Size(124, 15);
            lblTargetIP.TabIndex = 3;
            lblTargetIP.Text = "Target ATAK (IP:PORT):";
            // 
            // tbTargetIPAddresss
            // 
            tbTargetIPAddresss.Location = new Point(142, 16);
            tbTargetIPAddresss.Name = "tbTargetIPAddresss";
            tbTargetIPAddresss.Size = new Size(137, 23);
            tbTargetIPAddresss.TabIndex = 4;
            tbTargetIPAddresss.Text = "0.0.0.0";
            // 
            // btnSetTarget
            // 
            btnSetTarget.FlatStyle = FlatStyle.System;
            btnSetTarget.Location = new Point(337, 16);
            btnSetTarget.Name = "btnSetTarget";
            btnSetTarget.Size = new Size(48, 23);
            btnSetTarget.TabIndex = 5;
            btnSetTarget.Text = "Set";
            btnSetTarget.UseVisualStyleBackColor = true;
            btnSetTarget.Click += btnSetTarget_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(285, 16);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(46, 23);
            textBox1.TabIndex = 6;
            textBox1.Text = "4349";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 400);
            Controls.Add(textBox1);
            Controls.Add(btnSetTarget);
            Controls.Add(tbTargetIPAddresss);
            Controls.Add(lblTargetIP);
            Controls.Add(rtbLogs);
            MinimumSize = new Size(500, 300);
            Name = "MainWindow";
            Text = "A32TAK";
            Load += MainWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public RichTextBox rtbLogs;
        private Label lblTargetIP;
        private TextBox tbTargetIPAddresss;
        private Button btnSetTarget;
        private TextBox textBox1;
    }
}