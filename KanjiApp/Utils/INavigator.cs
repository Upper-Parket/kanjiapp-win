using KanjiApp.ViewModels;

namespace KanjiApp.Utils
{
    public interface INavigator
    {
        void PresentView(ViewModelBase viewModelBase);
        void OpenMainView();
    }
}