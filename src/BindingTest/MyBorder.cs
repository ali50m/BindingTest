using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BindingTest;

public class MyBorder : Border
{
    public bool IsChecked
    {
        get => (bool)GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    public static readonly DependencyProperty IsCheckedProperty =
        DependencyProperty.Register(nameof(IsChecked), typeof(bool), typeof(MyBorder),
            new PropertyMetadata(OnIsCheckedChanged));

    public Color OnBrush
    {
        get => (Color)GetValue(OnBrushProperty);
        set => SetValue(OnBrushProperty, value);
    }

    public static readonly DependencyProperty OnBrushProperty =
        DependencyProperty.Register(nameof(OnBrush), typeof(Color), typeof(MyBorder),
            new PropertyMetadata(Colors.LightGreen));

    private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var myBorder = (MyBorder)d;

        if (myBorder.IsChecked)
        {
            var colorAnimation = new ColorAnimation
            {
                To = myBorder.OnBrush,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };

            var storyboard = new Storyboard();
            storyboard.Children.Add(colorAnimation);

            Storyboard.SetTarget(colorAnimation, myBorder);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Background).(SolidColorBrush.Color)"));

            storyboard.Begin();
        }
        else
        {
            var colorAnimation = new ColorAnimation
            {
                To = Colors.Transparent,
                Duration = new Duration(TimeSpan.FromSeconds(1))
            };

            var storyboard = new Storyboard();
            storyboard.Children.Add(colorAnimation);

            Storyboard.SetTarget(colorAnimation, myBorder);
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Background).(SolidColorBrush.Color)"));

            storyboard.Begin();
        }
    }

    //private DispatcherTimer? _timer;

    //private static void OnBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //{
    //    var myBorder = (MyBorder)d;
    //    if (myBorder.IsChecked)
    //    {
    //        myBorder.AnimateColorChange((Color)e.OldValue, (Color)e.NewValue);
    //    }

    //    if (!myBorder.IsChecked)
    //    {
    //        myBorder.AnimateColorChange((Color)e.OldValue, (Color)Colors.Transparent);
    //    }
    //}

    //private void AnimateColorChange(Color fromColor, Color toColor)
    //{
    //    _timer?.Stop();

    //    _timer = new DispatcherTimer
    //    {
    //        Interval = TimeSpan.FromMilliseconds(1)
    //    };
    //    _timer.Tick += (_, _) =>
    //    {
    //        _timer.Stop();

    //        var storyboard = new Storyboard();
    //        var colorAnimation = new ColorAnimation(fromColor, toColor, new Duration(TimeSpan.FromSeconds(3)));

    //        Storyboard.SetTarget(colorAnimation, this);
    //        Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(Background).(SolidColorBrush.Color)"));

    //        storyboard.Children.Add(colorAnimation);
    //        storyboard.Begin();
    //    };

    //    _timer.Start();
    //}
}