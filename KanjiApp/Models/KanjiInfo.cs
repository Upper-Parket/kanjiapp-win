using System.Collections.Generic;

namespace KanjiApp.Models
{
    public class KanjiInfo
    {
        public string Kanji { get; set; }
        public IEnumerable<string> Ons { get; set; }
        public IEnumerable<string> Kuns { get; set; }
        public IEnumerable<string> Translations { get; set; }
        public int TimesGuessed { get; set; }
        public bool Enabled { get; set; }

        public static KanjiInfo GetDemo()
        {
            var kanji = new KanjiInfo
            {
                Kanji = "日",
                Ons = new[] { "nichi", "jitsu" },
                Kuns = new[] { "hi", "-bi", "-ka" },
                Translations = new[] { "day", "sun", "Japan", "counter for days" },
                TimesGuessed = 2,
                Enabled = true
            };
            return kanji;
        }
    }
}