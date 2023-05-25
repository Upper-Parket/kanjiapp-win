using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KanjiApp.Onboarding.Views
{
    public partial class LevelQuestionView : UserControl
    {
        public LevelQuestionView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}