using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KanjiApp.Views
{
    public partial class KanjiView : UserControl
    {
        public KanjiView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}