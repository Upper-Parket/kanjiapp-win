﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace KanjiApp.Views
{
    public partial class MainPageView : UserControl
    {
        public MainPageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}