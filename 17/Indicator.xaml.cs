using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _17
{
    /// <summary>
    /// Логика взаимодействия для Indicator.xaml
    /// </summary>
    public partial class Indicator : UserControl
    {
        public static readonly DependencyProperty ColorProperty =
        DependencyProperty.Register(
            nameof(Color),
            typeof(Color),
            typeof(Indicator),
            new FrameworkPropertyMetadata(
                Colors.White,
                0,
                new PropertyChangedCallback(OnColorChanged)));

        private static void OnColorChanged(DependencyObject sender,
                               DependencyPropertyChangedEventArgs e)
        {
            Color newColor = (Color)e.NewValue;
            Indicator colorpicker = (Indicator)sender;
            colorpicker.Red = newColor.R;
            colorpicker.Green = newColor.G;
            colorpicker.Blue = newColor.B;
        }

        private static void OnColorRGBChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            Indicator colorPicker = (Indicator)sender;
            Color color = colorPicker.Color;
            if (e.Property == RedProperty)
                color.R = (byte)e.NewValue;
            else if (e.Property == GreenProperty)
                color.G = (byte)e.NewValue;
            else if (e.Property == BlueProperty)
                color.B = (byte)e.NewValue;

            colorPicker.Color = color;
        }

        public static DependencyProperty RedProperty =

            RedProperty = DependencyProperty.Register(nameof(Red), typeof(byte), typeof(Indicator),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        public static DependencyProperty GreenProperty =

            GreenProperty = DependencyProperty.Register(nameof(Green), typeof(byte), typeof(Indicator),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));

        public static DependencyProperty BlueProperty =
            BlueProperty = DependencyProperty.Register(nameof(Blue), typeof(byte), typeof(Indicator),
                 new FrameworkPropertyMetadata(new PropertyChangedCallback(OnColorRGBChanged)));



        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value); 
        }

        public byte Red
        {
            get => (byte)GetValue(RedProperty); 
            set => SetValue(RedProperty, value); 
        }
        public byte Green
        {
            get => (byte)GetValue(GreenProperty);
            set => SetValue(GreenProperty, value); 
        }
        public byte Blue
        {
            get =>(byte)GetValue(BlueProperty); 
            set => SetValue(BlueProperty, value);
        }

        
        public static readonly RoutedEvent ColorChangedEvent=

        ColorChangedEvent = EventManager.RegisterRoutedEvent("ColorChanged", RoutingStrategy.Bubble,
        typeof(RoutedPropertyChangedEventHandler<Color>), typeof(ColorPicker));

        public event RoutedPropertyChangedEventHandler<Color> ColorChanged
        {
            add { AddHandler(ColorChangedEvent, value); }
            remove { RemoveHandler(ColorChangedEvent, value); }
        }

        public Indicator()
        {
            InitializeComponent();
        }
    }
}
