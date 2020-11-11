using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using NovelChecker.Models;
using NovelChecker.Utils;

namespace NovelChecker.Helper
{
    class NovelAnalysisHelper
    {
        /// <summary>
        /// 尝试解析小说
        /// </summary>
        /// <param name="txtContext"></param>
        /// <returns></returns>
        public static NovelAnalysisResultModel Analysis(byte[] txtContext)
        {
            string inputContext = string.Empty;
            NovelAnalysisResultModel textInfoModel = new NovelAnalysisResultModel();

            //自动判断编码，并获取文字
            if (!ConvertToString.FromByteArray(txtContext, out inputContext))
            {
                //获取失败
                textInfoModel.NovelWarnInfos.Add(new NovelWarnInfo() { WarnInfo = "自动判断编码失败，无法读取。" });
                return textInfoModel;
            }

            textInfoModel.NovelChapterModels = GetChaptersInfo(inputContext);
            textInfoModel.NovelWarnInfos.AddRange(CheckContinuity(textInfoModel.NovelChapterModels));
            textInfoModel.NovelWarnInfos.AddRange(CheckTitleRepeat(textInfoModel.NovelChapterModels));
            textInfoModel.NovelWarnInfos.AddRange(CheckRepeatAndEmpty(textInfoModel.NovelChapterModels, inputContext));
            textInfoModel.NovelWarnInfos.AddRange(CheckAdvertisement(inputContext));

            if (textInfoModel.NovelChapterModels.Count() == 0)
            {
                textInfoModel.NovelWarnInfos.Add(new NovelWarnInfo() { WarnInfo = "读取章节失败" });
            }
            return textInfoModel;
        }

        /// <summary>
        /// 删除重复行
        /// </summary>
        /// <param name="input">文本</param>
        /// <returns>无重复行文本</returns>
        private static string DeleteRepeatContext(string input)
        {
            return string.Join("\r\n", input.Replace("\r\n", "\n").Split('\n').Distinct().ToArray());
        }

        /// <summary>
        /// 获取小说章节信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static List<NovelChapterModel> GetChaptersInfo(string input)
        {
            List<NovelChapterModel> novelChapterModels = new List<NovelChapterModel>();
            string numberRegex = @"0-9零一二两三四五六七八九十百千万壹贰叁肆伍陆陸柒捌玖拾佰仟";
            string chapterRegex = @"章节回";

            Regex regexAllLine = new Regex(string.Format("^[ 　\t(正文)]*?第?[{0}]+[{1}].*", numberRegex, chapterRegex), RegexOptions.Compiled | RegexOptions.Multiline);
            Regex regexChapterNumberAll = new Regex(string.Format("第?[{0}]+[{1}]", numberRegex, chapterRegex), RegexOptions.Compiled);
            Regex regexChapterNumberOnly = new Regex(string.Format("[{0}]+", numberRegex), RegexOptions.Compiled | RegexOptions.Multiline);

            if (regexAllLine.Match(input).Value.Contains("第"))
            {
                regexAllLine = new Regex(string.Format("^[ 　\t(正文)]*?第[{0}]+[{1}].*", numberRegex, chapterRegex), RegexOptions.Compiled | RegexOptions.Multiline);
            }

            MatchCollection chapterTitles = regexAllLine.Matches(input);

            foreach (Match title in chapterTitles)
            {
                if (title.Value.Count() >= 2 && title.Value.Count() <= 50)
                {
                    string chapterNumber = regexChapterNumberAll.Match(title.Value).Value;
                    string chapterNumberOnly = regexChapterNumberOnly.Match(chapterNumber).Value;
                    string chapterName = title.Value.Replace(chapterNumber, "").Trim();

                    if (novelChapterModels.Count() > 0)
                    {
                        novelChapterModels.Last().EndIndex = title.Index - 1;
                    }

                    try
                    {
                        novelChapterModels.Add(new NovelChapterModel()
                        {
                            ChapterNumberRaw = regexChapterNumberAll.Match(title.Value).Value,
                            ChapterNumber = chapterNumberOnly.ObjToDecimal(),
                            ChapterName = chapterName,
                            StartIndex = title.Index
                        });
                    }
                    catch { }

                }
            }

            if (novelChapterModels.Count() > 0)
            {
                novelChapterModels.Last().EndIndex = input.Length - 1;
            }

            return novelChapterModels;
        }

        /// <summary>
        /// 检测章节的连续性
        /// </summary>
        /// <param name="chaptersInfo"></param>
        /// <returns></returns>
        private static List<NovelWarnInfo> CheckContinuity(List<NovelChapterModel> chaptersInfo)
        {
            List<NovelWarnInfo> novelWarnInfos = new List<NovelWarnInfo>();

            if (chaptersInfo.Count() <= 0) return novelWarnInfos;

            decimal prevChaptersNumber = chaptersInfo.First().ChapterNumber;
            bool prevHasWarning = false;

            foreach (NovelChapterModel chapter in chaptersInfo)
            {
                bool hasWarning = false;
                string warningInfo = string.Empty;

                //连续性检测
                //如果之前的章节没有问题，则正常检测
                //如果是第一章，不进行检测，并且刷新状态
                if (!prevHasWarning && chaptersInfo.ToList().IndexOf(chapter) != 0)
                {
                    if (chapter.ChapterNumber > prevChaptersNumber + 1)
                    {
                        //异常：第500章 => 第502章
                        warningInfo = (chapter.ChapterNumber - (prevChaptersNumber + 1)) == 1 ?
                            string.Format("第{0}章缺失", prevChaptersNumber + 1) : string.Format("第{0}～{1}章缺失。", prevChaptersNumber + 1, chapter.ChapterNumber);
                        hasWarning = true;
                    }
                    else if ((prevChaptersNumber + 1 > chapter.ChapterNumber) && (chapter.ChapterNumber != 1))
                    {
                        //异常：第500章 => 第499章
                        //正确情况：第500章 => 第1章
                        warningInfo = string.Format("第{0}章异常", chapter.ChapterNumber);
                        hasWarning = true;
                    }

                    if (hasWarning)
                    {
                        novelWarnInfos.Add(new NovelWarnInfo()
                        {
                            WarnInfo = warningInfo,
                            ChaptersInfo = chapter
                        });
                    }
                }
                else
                {
                    //如果之前的章节有问题， 将状态重置，更新最后一章的状态。
                    hasWarning = false;
                }

                prevChaptersNumber = chapter.ChapterNumber;
                prevHasWarning = hasWarning;
            }

            return novelWarnInfos;
        }

        /// <summary>
        /// 检测章节重复章节（章节名）
        /// </summary>
        /// <param name="chaptersInfo"></param>
        /// <returns></returns>
        private static List<NovelWarnInfo> CheckTitleRepeat(List<NovelChapterModel> chaptersInfo)
        {
            List<NovelWarnInfo> novelWarnInfos = new List<NovelWarnInfo>();

            if (chaptersInfo.Count() <= 0) return novelWarnInfos;

            for (int i = 0; i < chaptersInfo.Count(); i++)
            {
                var chapter = chaptersInfo.ElementAt(i);

                //获取章节号，章节名相同的章节
                var repeatChapter = (from x in chaptersInfo
                                     where
              x.ChapterNumber == chapter.ChapterNumber && x.ChapterName == chapter.ChapterName
                                     select x).ToArray();

                //如果存在多个重复章节，让后面的章节报错
                if (repeatChapter.Count() > 1 && chapter != repeatChapter.First())
                {
                    novelWarnInfos.Add(new NovelWarnInfo()
                    {
                        WarnInfo = string.Format("章节标题：【{0} {1}】 重复", chapter.ChapterNumberRaw, chapter.ChapterName),
                        ChaptersInfo = chapter
                    });
                }
            }

            return novelWarnInfos;
        }

        /// <summary>
        /// 检测重复内容
        /// </summary>
        /// <param name="chaptersInfo"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        private static List<NovelWarnInfo> CheckRepeatAndEmpty(List<NovelChapterModel> chaptersInfo, string context)
        {
            List<NovelWarnInfo> novelWarnInfos = new List<NovelWarnInfo>();

            //去重之后重新计算章节信息
            List<NovelChapterModel> noRepeatChapters = GetChaptersInfo(DeleteRepeatContext(context));

            //字数小于100的章节
            List<NovelChapterModel> shortContext = (from x in noRepeatChapters
                                                    where (x.EndIndex - x.StartIndex) < 100
                                                    select x).ToList();

            //找出哪一章重复了
            foreach (var chapter in shortContext)
            {
                //首先找到重复章的信息
                var sourceChapter = (from x in chaptersInfo where x.ChapterNumber == chapter.ChapterNumber select x).First();

                //找出重复章的原文
                string sourceChapterContext = context.Substring(sourceChapter.StartIndex, sourceChapter.EndIndex - sourceChapter.StartIndex);
                //重复内容在原文中的位置
                var contextDetail = sourceChapterContext.Split('\n');
                //空章节
                if (sourceChapterContext.Count() < 50)
                {
                    novelWarnInfos.Add(new NovelWarnInfo()
                    {
                        ChaptersInfo = sourceChapter,
                        WarnInfo = string.Format("章节{0}内容长度异常，可能是空章节", chapter.ChapterNumber)
                    });
                    continue;
                }

                int repeatContextIndex = context.IndexOf(sourceChapterContext.Split('\n')[1]);
                //找出位置对应的章节信息

                NovelChapterModel repeatSource = (from x in chaptersInfo where x.StartIndex > repeatContextIndex select x).First();
                if (repeatSource != null)
                {
                    if (chaptersInfo.ToList().IndexOf(repeatSource) > 0)
                    {
                        novelWarnInfos.Add(new NovelWarnInfo()
                        {
                            ChaptersInfo = sourceChapter,
                            WarnInfo = string.Format("章节{0}与章节{1}内容重复", chapter.ChapterNumber, repeatSource.ChapterNumber - 1)
                        });
                    }
                    else
                    {
                        //没有找到的话说明在第一张之前
                        novelWarnInfos.Add(new NovelWarnInfo()
                        {
                            ChaptersInfo = null,
                            WarnInfo = string.Format("章节{0}与开头内容重复", chapter.ChapterNumber)
                        });
                    }
                }
            }
            return novelWarnInfos;
        }

        private static List<NovelWarnInfo> CheckAdvertisement(string input)
        {
            List<NovelWarnInfo> novelWarnInfos = new List<NovelWarnInfo>();
            List<string> matchedString = new List<string>();
            Regex regexAdvertisement = new Regex(@"http|www|div|无弹窗|最新章节|全文阅读|免费阅读|TXT|(&#?\d*\w*;?)|[a-zA-Z*]{6,}|感谢.*打赏|灌溉营养液|扔了一个地雷|扔了一个火箭炮|扔了一个手榴弹|返回总目录", RegexOptions.Compiled);
            foreach (Match matched in regexAdvertisement.Matches(input))
            {
                if (!matchedString.Contains(matched.Value))
                {
                    novelWarnInfos.Add(new NovelWarnInfo()
                    {
                        WarnInfo = string.Format("疑似广告文字：{0}", matched.Value)
                    });
                    matchedString.Add(matched.Value);
                }
            }
            return novelWarnInfos;
        }
    }
}
