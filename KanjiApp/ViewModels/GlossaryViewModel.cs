using System.Collections.ObjectModel;
using KanjiApp.Models;
using KanjiApp.Utils;

namespace KanjiApp.ViewModels
{
    public class GlossaryViewModel : ViewModelBase
    {
        public ObservableCollection<KanjiViewModel> Items { get; }

        public GlossaryViewModel(INavigator? navigator) : base(navigator)
        {
            Items = new ObservableCollection<KanjiViewModel>();
            foreach (var kanji in KanjiInfo.LoadedKanjis) 
                Items.Add(new KanjiViewModel(kanji));
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