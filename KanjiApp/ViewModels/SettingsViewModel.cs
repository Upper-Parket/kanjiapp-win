using KanjiApp.Models;
using KanjiApp.Utils;
using ReactiveUI;

namespace KanjiApp.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private UserSettings? _userSettings;

        private int _kanjisPerPractice;

        public int KanjisPerPractice
        {
            get => _kanjisPerPractice;
            set => this.RaiseAndSetIfChanged(ref _kanjisPerPractice, value);
        }

        private string _currentSet;

        public string CurrentSet
        {
            get => _currentSet;
            set => this.RaiseAndSetIfChanged(ref _currentSet, value);
        }

        private int _guessedTillKnown;

        public int GuessedTillKnown
        {
            get => _guessedTillKnown;
            set => this.RaiseAndSetIfChanged(ref _guessedTillKnown, value);
        }

        public string Learned => "42/69";

        public SettingsViewModel(INavigator? navigator) : base(navigator)
        {
            _userSettings ??= UserSettings.GetDemo();
            KanjisPerPractice = _userSettings.KanjisPerPractice;
            CurrentSet = _userSettings.CurrentSet;
            GuessedTillKnown = _userSettings.GuessedTillKnown;
        }

        public SettingsViewModel() : this(null)
        {
        }

        public void Close()
        {
            Save();
            Navigator?.OpenMainView();
        }

        public void DecrementKanjisPerPractice()
        {
            KanjisPerPractice -= 1;
        }
        
        public void IncrementKanjisPerPractice()
        {
            KanjisPerPractice += 1;
        }

        public void DecrementGuessedTillLearned()
        {
            GuessedTillKnown -= 1;
        }
        
        public void IncrementGuessedTillLearned()
        {
            GuessedTillKnown += 1;
        }

        private void Save()
        {
            _userSettings = new UserSettings
            {
                GuessedTillKnown = GuessedTillKnown,
                CurrentSet = CurrentSet,
                KanjisPerPractice = KanjisPerPractice
            };
        }
    }
}