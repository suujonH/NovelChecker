using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// https://github.com/zmjack/Chinese
/// </summary>
namespace NovelChecker.Package.Chinese
{
    public class ChineseLexicon
    {
        public int WordMaxLength { get; }
        public Dictionary<string, int> Words { get; }

        public ChineseLexicon(Dictionary<string, int> words)
        {
            Words = words;
            WordMaxLength = Words.Max(x => x.Key.Length);
        }
    }
}
