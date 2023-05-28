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
        public int TotalCount => _kanjiInfos.Length;
        private readonly KanjiInfo[] _kanjiInfos;

        #region CircleContent

        private string _circleContent;

        public string CircleContent
        {
            get => _circleContent;
            set => this.RaiseAndSetIfChanged(ref _circleContent, value);
        }

        #endregion

        #region Index

        private int _index;

        public int Index
        {
            get => _index;
            set => this.RaiseAndSetIfChanged(ref _index, value);
        }

        #endregion

        #region Input

        private string _input;

        public string Input
        {
            get => _input;
            set => this.RaiseAndSetIfChanged(ref _input, value);
        }

        #endregion

        #region State

        private QuizState _quizState;

        public QuizState State
        {
            get => _quizState;
            set => this.RaiseAndSetIfChanged(ref _quizState, value);
        }

        #endregion

        #region RightButtonText

        private string _rightButtonText;

        public string RightButtonText
        {
            get => _rightButtonText;
            set => this.RaiseAndSetIfChanged(ref _rightButtonText, value);
        }

        #endregion

        #region CheckEnabled

        private bool _checkEnabled;

        public bool CheckEnabled
        {
            get => _checkEnabled;
            set => this.RaiseAndSetIfChanged(ref _checkEnabled, value);
        }

        #endregion

        #region TransformX

        private bool _moved;

        public bool Moved
        {
            get => _moved;
            set => this.RaiseAndSetIfChanged(ref _moved, value);
        }

        #endregion

        #region MyRegion

        private bool _answerShown;

        public bool AnswerShown
        {
            get => _answerShown;
            set => this.RaiseAndSetIfChanged(ref _answerShown, value);
        }

        #endregion

        #region Answer

        private string _currentOns;

        public string CurrentOns
        {
            get => _currentOns;
            set => this.RaiseAndSetIfChanged(ref _currentOns, value);
        }

        private string _currentKuns;

        public string CurrentKuns
        {
            get => _currentKuns;
            set => this.RaiseAndSetIfChanged(ref _currentKuns, value);
        }

        private string _currentTranslations;

        public string CurrentTranslations
        {
            get => _currentTranslations;
            set => this.RaiseAndSetIfChanged(ref _currentTranslations, value);
        }

        #endregion

        public QuizViewModel(INavigator? navigator) : base(navigator)
        {
            Index = 0;
            Moved = true;
            _kanjiInfos = KanjiInfo.GetDemoQuiz();
            State = QuizState.New;
            RightButtonText = "Reveal";
            CircleContent = _kanjiInfos[Index].Kanji;
            CheckEnabled = true;

            var checkEnabled = this.WhenAnyValue(x => x.CheckEnabled,
                x => x == true);
            OnCheck = ReactiveCommand.Create(Check, checkEnabled);
        }

        public QuizViewModel() : this(null)
        {
        }

        private void SetAnswer()
        {
            CurrentOns = _kanjiInfos[Index].GetOns();
            CurrentKuns = _kanjiInfos[Index].GetKuns();
            CurrentTranslations = _kanjiInfos[Index].GetTranslations();
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
            SetAnswer();
            AnswerShown = true;
            Moved = false;

            if (Index == TotalCount - 1)
                RightButtonText = "Results";
            else
                RightButtonText = "Next";
        }

        private void Next()
        {
            AnswerShown = false;
            Index += 1;
            State = QuizState.New;
            CheckEnabled = true;
            CircleContent = _kanjiInfos[Index].Kanji;
            Input = string.Empty;
            RightButtonText = "Reveal";
            Moved = true;
        }

        private void Results()
        {
            Index += 1;
            State = QuizState.New;
            AnswerShown = false;
            Moved = true;
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