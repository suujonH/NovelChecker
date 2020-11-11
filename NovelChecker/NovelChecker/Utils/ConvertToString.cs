using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NovelChecker.Utils
{
    public class ConvertToString
    {
        /// <summary>
        /// 将Byte转化为文字(自动识别文字编码)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public static bool FromByteArray(byte[] input, out string output)
        {
            bool res = false;
            output = string.Empty;

            //根据最可能(?)的编码排序
            Encoding[] encoding = new[] { Encoding.Default, Encoding.UTF8, Encoding.Unicode, Encoding.ASCII,
                                          Encoding.BigEndianUnicode, Encoding.UTF32, Encoding.UTF7};

            foreach (var enc in encoding)
            {
                string converted = enc.GetString(input);
                
                /*
                 * 我觉得...是个小说总会出现【的】吧？
                 * 或许有其他更好的方式？
                 */
                if (enc.GetString(input).Contains("的"))
                {
                    res = true;
                    output = converted;
                }
            }

            return res;
        }
    }
}
