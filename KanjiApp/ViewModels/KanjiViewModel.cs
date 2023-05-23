using KanjiApp.Models;

namespace KanjiApp.ViewModels
{
    public class KanjiViewModel : ViewModelBase
    {
        private readonly KanjiInfo _kanjiInfo;

        public string Kanji => _kanjiInfo.Kanji;
        public string Ons => string.Join(", ", _kanjiInfo.Ons);
        public string Kuns => string.Join(", ", _kanjiInfo.Kuns);
        public string Translations => string.Join(", ", _kanjiInfo.Translations);

        public KanjiViewModel()
        {
            _kanjiInfo = KanjiInfo.GetDemo();
        }
    }
}