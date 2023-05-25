using KanjiApp.Utils;

namespace KanjiApp.ViewModels
{
    public class QuizViewModel : ViewModelBase
    {
        public string Kanji => "test";

        public QuizViewModel(INavigator? navigator) : base(navigator)
        {
        }

        public QuizViewModel() : this(null)
        {
        }

        public void Close()
        {
            Navigator?.OpenMainView();
        }
    }
}