using KanjiApp.Onboarding.ViewModels;
using KanjiApp.Utils;
using ReactiveUI;

namespace KanjiApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, INavigator
    {
        private ViewModelBase _content;
        private readonly ViewModelBase _mainView;

        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }

        public MainWindowViewModel() : base(null)
        {
            _mainView = new MainPageViewModel(this);
            Content = new HelloViewModel(this);
        }

        public void PresentView(ViewModelBase viewModelBase)
        {
            Content = viewModelBase;
        }

        public void OpenMainView()
        {
            Content = _mainView;
        }
    }
}