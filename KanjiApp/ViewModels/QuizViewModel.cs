using System;
using System.Linq;
using System.Windows.Input;
using KanjiApp.Enums;
using KanjiApp.Models;
using KanjiApp.Utils;
using ReactiveUI;

namespace KanjiApp.ViewModels
{
    public class QuizViewModel : ViewModelBase
    {
        private string _circleContent;

        public string CircleContent
        {
            get => _circleContent;
            set => this.RaiseAndSetIfChanged(ref _circleContent, value);
        }

        public int TotalCount => _kanjiInfos.Length;
        private readonly KanjiInfo[] _kanjiInfos;
        
        private int _index;

        public int Index
        {
            get => _index;
            set => this.RaiseAndSetIfChanged(ref _index, value);
        }

        private string _input;

        public string Input
        {
            get => _input;
            set => this.RaiseAndSetIfChanged(ref _input, value);
        }

        private QuizState _quizState;

        public QuizState State
        {
            get => _quizState;
            set => this.RaiseAndSetIfChanged(ref _quizState, value);
        }

        private string _rightButtonText;

        public string RightButtonText
        {
            get => _rightButtonText;
            set => this.RaiseAndSetIfChanged(ref _rightButtonText, value);
        }

        private bool _checkEnabled;

        public bool CheckEnabled
        {
            get => _checkEnabled;
            set => this.RaiseAndSetIfChanged(ref _checkEnabled, value);
        }
        
        public QuizViewModel(INavigator? navigator) : base(navigator)
        {
            _kanjiInfos = KanjiInfo.GetDemoQuiz();
            Index = 0;
            State = QuizState.New;
            RightButtonText = "Reveal";
            CircleContent = _kanjiInfos[_index].Kanji;
            CheckEnabled = true;

            var checkEnabled = this.WhenAnyValue(x => x.CheckEnabled,
                x => x == true);
            OnCheck = ReactiveCommand.Create(Check, checkEnabled);
        }

        public QuizViewModel() : this(null)
        {
        }

        public void Close()
        {
            Navigator?.OpenMainView();
        }
        
        public ICommand OnCheck { get; }
        
        private void Check()
        {
            var result = _kanjiInfos[Index].Kuns.Contains(Input) || _kanjiInfos[Index].Ons.Contains(Input);
            if (result)
                Reveal();
            
            State = result
                ? QuizState.GuessedCorrectly
                : QuizState.GuessedWrong;
        }

        public void RightButton()
        {
            if (RightButtonText == "Reveal")
                Reveal();
            else if (RightButtonText == "Next")
                Next();
            else if (RightButtonText == "Results")
                Results();
            else if (RightButtonText == "Finish")
                Finish();
        }

        private void Reveal()
        {
            CheckEnabled = false;
            if (Index == TotalCount - 1)
                RightButtonText = "Results";
            else
                RightButtonText = "Next";
            
            // todo show kanji info
            
        }

        private void Next()
        {
            Index += 1;
            State = QuizState.New;
            CheckEnabled = true;
            CircleContent = _kanjiInfos[Index].Kanji;
            Input = string.Empty;
            RightButtonText = "Reveal";
        }

        private void Results()
        {
            Input = string.Empty;
            CheckEnabled = false;
            CircleContent = "42/69";
            RightButtonText = "Finish";
        }

        private void Finish()
        {
            Close();
        }
    }
}