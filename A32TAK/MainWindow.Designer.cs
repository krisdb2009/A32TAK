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
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label1 = new Label();
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
            tbTargetIPAddresss.Size = new Size(98, 23);
            tbTargetIPAddresss.TabIndex = 4;
            tbTargetIPAddresss.Text = "0.0.0.0";
            // 
            // btnSetTarget
            // 
            btnSetTarget.FlatStyle = FlatStyle.System;
            btnSetTarget.Location = new Point(353, 102);
            btnSetTarget.Name = "btnSetTarget";
            btnSetTarget.Size = new Size(48, 23);
            btnSetTarget.TabIndex = 5;
            btnSetTarget.Text = "Set";
            btnSetTarget.UseVisualStyleBackColor = true;
            btnSetTarget.Click += btnSetTarget_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(246, 16);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(46, 23);
            textBox1.TabIndex = 6;
            textBox1.Text = "4349";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(142, 45);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(46, 23);
            textBox2.TabIndex = 7;
            textBox2.Text = "4349";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(194, 45);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(46, 23);
            textBox3.TabIndex = 8;
            textBox3.Text = "4349";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(246, 45);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(46, 23);
            textBox4.TabIndex = 9;
            textBox4.Text = "4349";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.FlatStyle = FlatStyle.System;
            label1.Location = new Point(12, 48);
            label1.Name = "label1";
            label1.Size = new Size(124, 15);
            label1.TabIndex = 10;
            label1.Text = "Target ATAK (IP:PORT):";
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(651, 400);
            Controls.Add(label1);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
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
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label1;
    }
}