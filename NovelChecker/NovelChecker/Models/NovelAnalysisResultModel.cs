using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovelChecker.Models
{
    /// <summary>
    /// 处理结果
    /// </summary>
    class NovelAnalysisResultModel
    {
        /// <summary>
        /// 小说路径
        /// </summary>
        public string NovelPath { get; set; }

        /// <summary>
        /// 小说章节信息
        /// </summary>
        public List<NovelChapterModel> NovelChapterModels { get; set; } = new List<NovelChapterModel>();

        /// <summary>
        /// 警告信息
        /// </summary>
        public List<NovelWarnInfo> NovelWarnInfos { get; set; } = new List<NovelWarnInfo>();
    }
}
