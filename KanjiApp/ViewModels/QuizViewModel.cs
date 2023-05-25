using KanjiApp.Utils;

namespace KanjiApp.ViewModels
{
    public class QuizViewModel : ViewModelBase
    {
        private readonly INavigator? _navigator;

        public string Kanji => "test";

        public QuizViewModel(INavigator? navigator)
        {
            _navigator = navigator;
        }

        public QuizViewModel() : this(null)
        {
        }

        public void Close()
        {
            _navigator?.OpenMainView();
        }
    }
}