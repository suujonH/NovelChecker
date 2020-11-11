using NovelChecker.Helper;
using NovelChecker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NovelChecker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            InitializeLayout();
        }

        #region 控件相关基本设定
        /// <summary>
        /// 初始化控件样式
        /// </summary>
        public void InitializeLayout()
        {
            this.AllowDrop = true;
            this.DragDrop += Control_DragDrop;
            this.DragEnter += Control_DragEnter;
            this.StartPosition = FormStartPosition.CenterScreen;

            gdvChaptersInfo.AllowUserToAddRows = false;
            gdvChaptersInfo.AllowUserToDeleteRows = false;
            gdvChaptersInfo.AllowUserToResizeRows = false;
            gdvChaptersInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gdvChaptersInfo.AutoGenerateColumns = false;
            gdvChaptersInfo.RowHeadersVisible = false;
            gdvChaptersInfo.MultiSelect = false;
            gdvChaptersInfo.ReadOnly = true;

            gdvChaptersInfo.Columns.Add(new DataGridViewTextBoxColumn
            {
                 AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                 DataPropertyName = nameof(NovelChapterModel.ChapterNumberRaw),
                 FillWeight = 30,
                 HeaderText = "章节号"
            });
            gdvChaptersInfo.Columns.Add(new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = nameof(NovelChapterModel.ChapterName),
                FillWeight = 40,
                HeaderText = "章节名"
            });
            gdvChaptersInfo.Columns.Add(new DataGridViewTextBoxColumn
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataPropertyName = nameof(NovelChapterModel.WordsCount),
                FillWeight = 30,
                HeaderText = "章节字数"
            });

            lsbChaptersInfo.DisplayMember = nameof(NovelChecker.Models.NovelWarnInfo.WarnInfo);
            this.Icon = Properties.Resources.winking_face;
        }

        /// <summary>
        /// 拖拽动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] rs = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (rs.Count() > 0)
                {
                    txbPath.Text = rs[0];
                }
            }
        }

        /// <summary>
        /// 拖拽动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_DragEnter(object sender, DragEventArgs e)
        {
            //只允许文件拖放
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 浏览按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "文本文件(*.txt)|*.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                txbPath.Text = fileDialog.FileName;
            }
        }

        /// <summary>
        /// 打开按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, EventArgs e)
        {
            StartAnalysis(txbPath.Text);
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsiAbout_Click(object sender, EventArgs e)
        {
            new frmAbout().ShowDialog();
        }
        #endregion

        /// <summary>
        /// 开始处理
        /// </summary>
        /// <param name="filePath"></param>
        private void StartAnalysis(string filePath)
        {
            var result = NovelAnalysisHelper.Analysis(File.ReadAllBytes(filePath));
            gdvChaptersInfo.DataSource = result.NovelChapterModels;
            lsbChaptersInfo.DataSource = result.NovelWarnInfos;
        }
    }

}
