namespace NovelChecker
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mnsMenu = new System.Windows.Forms.MenuStrip();
            this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlFull = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lsbChaptersInfo = new System.Windows.Forms.ListBox();
            this.gdvChaptersInfo = new System.Windows.Forms.DataGridView();
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txbPath = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.mnsMenu.SuspendLayout();
            this.pnlFull.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvChaptersInfo)).BeginInit();
            this.stsStatus.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsMenu
            // 
            this.mnsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmHelp});
            this.mnsMenu.Location = new System.Drawing.Point(0, 0);
            this.mnsMenu.Name = "mnsMenu";
            this.mnsMenu.Size = new System.Drawing.Size(800, 25);
            this.mnsMenu.TabIndex = 0;
            this.mnsMenu.Text = "menuStrip1";
            // 
            // tsmHelp
            // 
            this.tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsiAbout});
            this.tsmHelp.Name = "tsmHelp";
            this.tsmHelp.Size = new System.Drawing.Size(44, 21);
            this.tsmHelp.Text = "帮助";
            // 
            // tsiAbout
            // 
            this.tsiAbout.Name = "tsiAbout";
            this.tsiAbout.Size = new System.Drawing.Size(180, 22);
            this.tsiAbout.Text = "关于";
            this.tsiAbout.Click += new System.EventHandler(this.tsiAbout_Click);
            // 
            // pnlFull
            // 
            this.pnlFull.Controls.Add(this.pnlMain);
            this.pnlFull.Controls.Add(this.stsStatus);
            this.pnlFull.Controls.Add(this.pnlTop);
            this.pnlFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFull.Location = new System.Drawing.Point(0, 25);
            this.pnlFull.Name = "pnlFull";
            this.pnlFull.Size = new System.Drawing.Size(800, 425);
            this.pnlFull.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lsbChaptersInfo);
            this.pnlMain.Controls.Add(this.gdvChaptersInfo);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 40);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 363);
            this.pnlMain.TabIndex = 8;
            // 
            // lsbChaptersInfo
            // 
            this.lsbChaptersInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsbChaptersInfo.FormattingEnabled = true;
            this.lsbChaptersInfo.ItemHeight = 12;
            this.lsbChaptersInfo.Location = new System.Drawing.Point(527, 3);
            this.lsbChaptersInfo.Name = "lsbChaptersInfo";
            this.lsbChaptersInfo.Size = new System.Drawing.Size(270, 352);
            this.lsbChaptersInfo.TabIndex = 1;
            // 
            // gdvChaptersInfo
            // 
            this.gdvChaptersInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvChaptersInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvChaptersInfo.Location = new System.Drawing.Point(14, 3);
            this.gdvChaptersInfo.Name = "gdvChaptersInfo";
            this.gdvChaptersInfo.RowTemplate.Height = 23;
            this.gdvChaptersInfo.Size = new System.Drawing.Size(507, 352);
            this.gdvChaptersInfo.TabIndex = 0;
            // 
            // stsStatus
            // 
            this.stsStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.stsStatus.Location = new System.Drawing.Point(0, 403);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(800, 22);
            this.stsStatus.TabIndex = 7;
            this.stsStatus.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(134, 17);
            this.lblStatus.Text = "小说检查器 -- 豆沙团子";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblPath);
            this.pnlTop.Controls.Add(this.btnBrowser);
            this.pnlTop.Controls.Add(this.txbPath);
            this.pnlTop.Controls.Add(this.btnOpen);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(800, 40);
            this.pnlTop.TabIndex = 6;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 12);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(53, 12);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "小说位置";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowser.Location = new System.Drawing.Point(632, 8);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(75, 22);
            this.btnBrowser.TabIndex = 5;
            this.btnBrowser.Text = "浏览...";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txbPath
            // 
            this.txbPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbPath.Location = new System.Drawing.Point(71, 9);
            this.txbPath.Name = "txbPath";
            this.txbPath.Size = new System.Drawing.Size(555, 21);
            this.txbPath.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(713, 9);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 22);
            this.btnOpen.TabIndex = 4;
            this.btnOpen.Text = "打开";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlFull);
            this.Controls.Add(this.mnsMenu);
            this.MainMenuStrip = this.mnsMenu;
            this.Name = "frmMain";
            this.Text = "小说章节检查器";
            this.mnsMenu.ResumeLayout(false);
            this.mnsMenu.PerformLayout();
            this.pnlFull.ResumeLayout(false);
            this.pnlFull.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvChaptersInfo)).EndInit();
            this.stsStatus.ResumeLayout(false);
            this.stsStatus.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmHelp;
        private System.Windows.Forms.ToolStripMenuItem tsiAbout;
        private System.Windows.Forms.Panel pnlFull;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ListBox lsbChaptersInfo;
        private System.Windows.Forms.DataGridView gdvChaptersInfo;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txbPath;
        private System.Windows.Forms.Button btnOpen;
    }
}

