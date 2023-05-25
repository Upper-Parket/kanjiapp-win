using KanjiApp.Utils;
using ReactiveUI;

namespace KanjiApp.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected INavigator? Navigator { get; }

        protected ViewModelBase(INavigator? navigator)
        {
            Navigator = navigator;
        }
    }
}