namespace A32TAK
{
    partial class About
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
            lblVersion = new Label();
            lblVersionV = new Label();
            lblCredits = new Label();
            SuspendLayout();
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.FlatStyle = FlatStyle.System;
            lblVersion.Location = new Point(12, 9);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(48, 15);
            lblVersion.TabIndex = 0;
            lblVersion.Text = "Version:";
            // 
            // lblVersionV
            // 
            lblVersionV.AutoSize = true;
            lblVersionV.FlatStyle = FlatStyle.System;
            lblVersionV.Location = new Point(66, 9);
            lblVersionV.Name = "lblVersionV";
            lblVersionV.Size = new Size(40, 15);
            lblVersionV.TabIndex = 1;
            lblVersionV.Text = "0.0.0.0";
            // 
            // lblCredits
            // 
            lblCredits.AutoSize = true;
            lblCredits.FlatStyle = FlatStyle.System;
            lblCredits.Location = new Point(12, 37);
            lblCredits.Name = "lblCredits";
            lblCredits.Size = new Size(251, 15);
            lblCredits.TabIndex = 2;
            lblCredits.Text = "Written by Dylan B / Kevin B";
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 70);
            Controls.Add(lblCredits);
            Controls.Add(lblVersionV);
            Controls.Add(lblVersion);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "About";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About A32TAK";
            Load += About_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblVersion;
        private Label lblVersionV;
        private Label lblCredits;
    }
}
