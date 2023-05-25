using System.Collections.ObjectModel;
using KanjiApp.Utils;

namespace KanjiApp.ViewModels
{
    public class GlossaryViewModel : ViewModelBase
    {
        public ObservableCollection<KanjiViewModel> Items { get; }

        public GlossaryViewModel(INavigator? navigator) : base(navigator)
        {
            Items = new ObservableCollection<KanjiViewModel>();
            for (var index = 0; index < 50; index++)
                Items.Add(new KanjiViewModel());
        }

        public GlossaryViewModel() : this(null)
        {
        }

        public void Close()
        {
            Navigator?.OpenMainView();
        }
    }
}