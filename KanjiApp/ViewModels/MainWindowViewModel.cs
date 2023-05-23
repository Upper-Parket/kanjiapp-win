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

        public MainWindowViewModel()
        {
            _mainView = new MainPageViewModel(this);
            Content = _mainView;
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