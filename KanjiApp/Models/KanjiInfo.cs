using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KanjiApp.Enums;
using KanjiApp.PathHelper.Paths;
using Newtonsoft.Json;

namespace KanjiApp.Models
{
    public class KanjiInfo
    {
        private static KanjiInfo[]? _loadedKanjis;

        internal static KanjiInfo[] LoadedKanjis
        {
            get => _loadedKanjis ??= LoadSetAsync(KanjiSet.N5);
            private set => _loadedKanjis = value;
        }

        public string Kanji { get; }
        public IEnumerable<string> Ons { get; }
        public IEnumerable<string> Kuns { get; }
        public IEnumerable<string> Translations { get; }
        public int TimesGuessed { get; set; } = 0;
        public bool Enabled { get; set; } = false;

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

        private static KanjiInfo[] LoadSetAsync(KanjiSet set)
        {
            var file = set switch
            {
                KanjiSet.N5 => PathFinder.N5SetFile,
                KanjiSet.N4 => PathFinder.N4SetFile,
                KanjiSet.N3 => PathFinder.N3SetFile,
                KanjiSet.N2 => PathFinder.N2SetFile,
                _ => throw new ArgumentOutOfRangeException(nameof(set), set, null)
            };

            var text = File.ReadAllText(file);
            var kanjis = JsonConvert.DeserializeObject<KanjiInfo[]>(text);
            return kanjis!;
        }

        public string GetOns() => GetCollectionAsString(Ons);
        public string GetKuns() => GetCollectionAsString(Kuns);
        public string GetTranslations() => GetCollectionAsString(Translations);

        private static string GetCollectionAsString(IEnumerable<string> collection)
        {
            var array = collection as string[] ?? collection.ToArray();
            return array.Any()
                ? string.Join(", ", array)
                : string.Empty;
        }

        public static KanjiInfo GetDemo()
        {
            var kanji = new KanjiInfo("日", new[] { "nichi", "jitsu" }, new[] { "hi", "-bi", "-ka" },
                new[] { "day", "sun", "Japan", "counter for days" });
            return kanji;
        }

        public static KanjiInfo[] GetForQuiz(int count)
        {
            if (count > LoadedKanjis!.Length)
                count = LoadedKanjis.Length;

            var result = new HashSet<KanjiInfo>();
            var random = new Random();

            while (result.Count != count)
            {
                var index = random.Next(0, LoadedKanjis.Length);
                result.Add(LoadedKanjis[index]);
            }

            return result.ToArray();
        }

        public override int GetHashCode()
        {
            return Kanji.GetHashCode();
        }
    }
}