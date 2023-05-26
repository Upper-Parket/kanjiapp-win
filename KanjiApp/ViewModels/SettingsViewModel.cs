using System.Collections.Generic;
using System.Windows.Input;
using KanjiApp.UserSettingsHelper;
using KanjiApp.Utils;
using ReactiveUI;

namespace KanjiApp.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        public IEnumerable<string> ComboboxItems => new[] { "N5", "N4", "N3", "N2", "N1", "Custom 1" };
        
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
            var userSettings = SettingsInstance.UserSettings;
            KanjisPerPractice = userSettings.KanjisPerPractice;
            CurrentSet = userSettings.CurrentSet;
            GuessedTillKnown = userSettings.GuessedTillKnown;

            var decrementKanjisEnabled = this.WhenAnyValue(x => x.KanjisPerPractice,
                x => x > 1);
            OnDecrementKanjisPerPractice = ReactiveCommand.Create(DecrementKanjisPerPractice, decrementKanjisEnabled);
            var incrementKanjisEnabled = this.WhenAnyValue(x => x.KanjisPerPractice,
                x => x < 50);
            OnIncrementKanjisPerPractice = ReactiveCommand.Create(IncrementKanjisPerPractice, incrementKanjisEnabled);

            var decrementGuessedEnabled = this.WhenAnyValue(x => x.GuessedTillKnown,
                x => x > 1);
            OnDecrementGuessedTillLearned = ReactiveCommand.Create(DecrementGuessedTillLearned, decrementGuessedEnabled);
            var incrementGuessedEnabled = this.WhenAnyValue(x => x.GuessedTillKnown,
                x => x < 50);
            OnIncrementGuessedTillLearned = ReactiveCommand.Create(IncrementGuessedTillLearned, incrementGuessedEnabled);
        }

        public SettingsViewModel() : this(null)
        {
        }

        public ICommand OnDecrementKanjisPerPractice { get; }
        public ICommand OnIncrementKanjisPerPractice { get; }
        public ICommand OnDecrementGuessedTillLearned { get; }
        public ICommand OnIncrementGuessedTillLearned { get; }

        public void Close()
        {
            Save();
            Navigator?.OpenMainView();
        }

        private void DecrementKanjisPerPractice()
        {
            KanjisPerPractice -= 1;
        }

        private void IncrementKanjisPerPractice()
        {
            KanjisPerPractice += 1;
        }

        private void DecrementGuessedTillLearned()
        {
            GuessedTillKnown -= 1;
        }

        private void IncrementGuessedTillLearned()
        {
            GuessedTillKnown += 1;
        }

        private void Save()
        {
            SettingsInstance.Save(new UserSettings
            {
                CurrentSet = CurrentSet,
                KanjisPerPractice = KanjisPerPractice,
                GuessedTillKnown = GuessedTillKnown
            });
        }
    }
}