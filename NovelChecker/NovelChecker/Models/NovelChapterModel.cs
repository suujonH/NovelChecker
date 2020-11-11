using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovelChecker.Models
{
    /// <summary>
    /// 小说章节信息
    /// </summary>
    class NovelChapterModel
    {
        /// <summary>
        /// 章节数（原文字）
        /// </summary>
        public string ChapterNumberRaw { get; set; }

        /// <summary>
        /// 章节数
        /// </summary>
        public decimal ChapterNumber { get; set; }

        /// <summary>
        /// 章节名
        /// </summary>
        public string ChapterName { get; set; }

        /// <summary>
        /// 开始Index
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// 结束Index
        /// </summary>
        public int EndIndex { get; set; }

        /// <summary>
        /// 结束Index
        /// </summary>
        public int WordsCount 
        {
            get
            {
                return EndIndex - StartIndex;
            }
        }
    }
}
