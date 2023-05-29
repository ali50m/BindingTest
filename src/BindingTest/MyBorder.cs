using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BindingTest;

public class MyBorder : Border
{
    public Color OnBrush
    {
        get => (Color)GetValue(OnBrushProperty);
        set => SetValue(OnBrushProperty, value);
    }

    public static readonly DependencyProperty OnBrushProperty =
        DependencyProperty.Register(nameof(OnBrush), typeof(Color), typeof(MyBorder), new PropertyMetadata(Colors.LightGreen));
}