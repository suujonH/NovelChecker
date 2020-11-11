using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// https://github.com/zmjack/Chinese
/// </summary>
namespace NovelChecker.Package.Chinese
{
    public static class ChineseTokenizer
    {
        public static string[] SplitWords(string chinese)
        {
            var lexicon = ChineseNumerical.Lexion;
            if (lexicon is null) return chinese.Select(ch => ch.ToString()).ToArray();

            var list = new LinkedList<string>();
            var length = chinese.Length;

            var maxOffset = Math.Min(chinese.Length, lexicon.WordMaxLength);
            var ptext = length - maxOffset;
            var maxLengthPerTurn = maxOffset;
            int matchLength;
            for (; ptext + maxLengthPerTurn >= 0; ptext -= matchLength)
            {
                matchLength = 1;
                for (var i = ptext > 0 ? 0 : -ptext; i < maxLengthPerTurn; i++)
                {
                    var part = chinese.Substring(ptext + i, maxLengthPerTurn - i);
                    if (part.Length == 1)
                    {
                        list.AddFirst(part);
                        break;
                    }
                    else
                    {
                        var match = Match(lexicon, part);
                        if (match != null)
                        {
                            list.AddFirst(match);
                            matchLength = match.Length;
                            break;
                        }
                    }
                }
            }

            return list.ToArray();
        }

        private static string Match(ChineseLexicon lexicon, string part)
        {
            var isMatch = lexicon.Words.Any(x => x.Key == part);
            return isMatch ? part : null;
        }

    }
}
