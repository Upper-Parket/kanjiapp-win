using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KanjiApp.Views
{
    public partial class GlossaryView : UserControl
    {
        public GlossaryView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}