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

        public KanjiInfo(string kanji, IEnumerable<string> ons, IEnumerable<string> kuns,
            IEnumerable<string> translations, int timesGuessed = 0, bool enabled = true)
        {
            Kanji = kanji;
            Ons = ons;
            Kuns = kuns;
            Translations = translations;
            TimesGuessed = timesGuessed;
            Enabled = enabled;
        }

        public static KanjiInfo GetDemo()
        {
            var kanji = new KanjiInfo("日", new[] { "nichi", "jitsu" }, new[] { "hi", "-bi", "-ka" },
                new[] { "day", "sun", "Japan", "counter for days" });
            return kanji;
        }

        public static KanjiInfo[] GetDemoQuiz()
        {
            return new[]
            {
                new KanjiInfo("日", new[] { "nichi", "jitsu" }, new[] { "hi", "-bi", "-ka" },
                    new[] { "day", "sun", "Japan", "counter for days" }),
                new KanjiInfo("一", new[] { "ichi" }, new[] { "hito(tsu)" },
                    new[] { "one" }),
                new KanjiInfo("国", new[] { "koku" },
                    new[] { "kuni" }, new[] { "country" })
            };
        }
    }
}