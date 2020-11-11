namespace NovelChecker
{
    partial class frmAbout
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
            this.lblVersionInfo = new System.Windows.Forms.Label();
            this.lblVersionHint = new System.Windows.Forms.Label();
            this.lvlAppName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVersionInfo
            // 
            this.lblVersionInfo.AutoSize = true;
            this.lblVersionInfo.Location = new System.Drawing.Point(27, 45);
            this.lblVersionInfo.Name = "lblVersionInfo";
            this.lblVersionInfo.Size = new System.Drawing.Size(29, 12);
            this.lblVersionInfo.TabIndex = 0;
            this.lblVersionInfo.Text = "版本";
            // 
            // lblVersionHint
            // 
            this.lblVersionHint.AutoSize = true;
            this.lblVersionHint.Location = new System.Drawing.Point(82, 45);
            this.lblVersionHint.Name = "lblVersionHint";
            this.lblVersionHint.Size = new System.Drawing.Size(47, 12);
            this.lblVersionHint.TabIndex = 1;
            this.lblVersionHint.Text = "1.0.0.0";
            // 
            // lvlAppName
            // 
            this.lvlAppName.AutoSize = true;
            this.lvlAppName.Location = new System.Drawing.Point(35, 20);
            this.lvlAppName.Name = "lvlAppName";
            this.lvlAppName.Size = new System.Drawing.Size(89, 12);
            this.lvlAppName.TabIndex = 2;
            this.lvlAppName.Text = "小说章节检查器";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(154, 81);
            this.Controls.Add(this.lvlAppName);
            this.Controls.Add(this.lblVersionHint);
            this.Controls.Add(this.lblVersionInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "关于";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersionInfo;
        private System.Windows.Forms.Label lblVersionHint;
        private System.Windows.Forms.Label lvlAppName;
    }
}