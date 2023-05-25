using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;

namespace KanjiApp.Onboarding.Views
{
    public partial class WhatIsYourLevelView : UserControl
    {
        public WhatIsYourLevelView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}