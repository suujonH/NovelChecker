using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NovelChecker.Package.Chinese;

namespace NovelChecker.Utils
{
    public static class UtilConvert
    {
        public static decimal ObjToDecimal(this object thisValue)
        {
            decimal reval = 0;
            if (thisValue == null) return 0;

            if (!decimal.TryParse(thisValue.ToString(), out reval))
            {
                var words = ChineseTokenizer.SplitWords(thisValue.ToString());

                foreach (var word in words)
                {
                    if (word == "零") continue;
                    else if (word == "十" || word == "拾") reval += 10;
                    else
                    {
                        int numericalNumber;
                        if (ChineseNumerical.Numerical.TryGetValue(word, out numericalNumber))
                        {
                            reval += numericalNumber;
                        }
                        else
                        {
                            throw new ArgumentException($"不能解析的词汇：{word}");
                        }

                    }
                }
            }

            return reval;
        }
    }
}
