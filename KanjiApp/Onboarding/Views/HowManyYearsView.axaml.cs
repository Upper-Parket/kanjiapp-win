using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KanjiApp.Onboarding.Views
{
    public partial class HowManyYearsView : UserControl
    {
        public HowManyYearsView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}