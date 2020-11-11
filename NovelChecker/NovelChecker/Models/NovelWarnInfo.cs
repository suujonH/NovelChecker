using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovelChecker.Models
{
    /// <summary>
    /// 警告信息
    /// </summary>
    class NovelWarnInfo
    {
        /// <summary>
        /// 警告信息
        /// </summary>
        public string WarnInfo { get; set; }
        /// <summary>
        /// 章节信息
        /// </summary>
        public NovelChapterModel ChaptersInfo { get; set; }
    }
}
