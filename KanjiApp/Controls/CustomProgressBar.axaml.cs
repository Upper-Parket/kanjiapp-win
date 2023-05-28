using System;
using System.Linq;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace KanjiApp.Controls
{
    public class CustomProgressBar : TemplatedControl
    {
        private bool _transitionAdded;

        public static readonly StyledProperty<double> MaximumProperty =
            AvaloniaProperty.Register<CustomProgressBar, double>(nameof(Maximum));

        public double Maximum
        {
            get => GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, value);
        }

        public static readonly StyledProperty<double> ValueProperty =
            AvaloniaProperty.Register<CustomProgressBar, double>(nameof(Value));

        public double Value
        {
            get => GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        static CustomProgressBar()
        {
            MaximumProperty.Changed.AddClassHandler<CustomProgressBar>((x, e) => x.UpdateWhenPropChanged(e));
            ValueProperty.Changed.AddClassHandler<CustomProgressBar>((x, e) => x.UpdateWhenPropChanged(e));
        }

        private void UpdateWhenPropChanged(AvaloniaPropertyChangedEventArgs e)
        {
            UpdateIndicator(Bounds.Size);
        }

        private void UpdateIndicator(Size bounds)
        {
            if (!VisualChildren.Any()) return;
            if (VisualChildren[0] is not Grid grid) return;
            if (grid.Children.Count != 2) return;
            if (grid.Children[1] is not Border border) return;

            if (!_transitionAdded)
            {
                border.Transitions ??= new Transitions();
                border.Transitions.Add(
                    new DoubleTransition
                    {
                        Property = WidthProperty,
                        Duration = TimeSpan.FromSeconds(0.5)
                    });
                _transitionAdded = true;
            }

            var total = Maximum;
            var value = Value;

            var percentage = value / total;
            var width = bounds.Width * percentage;

            border.Width = width;
        }
    }
}