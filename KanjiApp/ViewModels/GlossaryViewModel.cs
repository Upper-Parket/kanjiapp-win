using System.Collections.ObjectModel;
using KanjiApp.Utils;

namespace KanjiApp.ViewModels
{
    public class GlossaryViewModel : ViewModelBase
    {
        private readonly INavigator? _navigator;
        public ObservableCollection<KanjiViewModel> Items { get; }

        public GlossaryViewModel(INavigator? navigator = null)
        {
            _navigator = navigator;
            Items = new ObservableCollection<KanjiViewModel>();
            for (var index = 0; index < 50; index++) 
                Items.Add(new KanjiViewModel());
        }

        public void Close()
        {
            _navigator?.OpenMainView();
        }
    }
}