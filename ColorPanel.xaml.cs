using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess
{
    public partial class ColorPanel : Window
    {
        private Slider sRed;
        private Slider sGreen;
        private Slider sBlue;
        private byte red;
        private byte green;
        private byte blue;
        Label selectedColorBaner;
        public Color selectedColor;
        public ColorPanel(Color bColor)
        {
            InitializeComponent();
            selectedColor = bColor;
            red = selectedColor.R;
            green = selectedColor.G;
            blue = selectedColor.B;
            sRed = new Slider();
            sRed.Minimum = 0;
            sRed.Maximum = 255;
            sRed.Value = red;
            sRed.ValueChanged += updateValue;
            Grid.SetColumn(sRed, 3);
            Grid.SetRow(sRed, 1);
            ColorOptions.Children.Add(sRed);
            sGreen = new Slider();
            sGreen.Minimum = 0;
            sGreen.Maximum = 255;
            sGreen.Value = green;
            sGreen.ValueChanged += updateValue;
            Grid.SetColumn(sGreen, 3);
            Grid.SetRow(sGreen, 3);
            ColorOptions.Children.Add(sGreen);
            sBlue = new Slider();
            sBlue.Minimum = 0;
            sBlue.Maximum = 255;
            sBlue.Value = blue;
            sBlue.ValueChanged += updateValue;
            Grid.SetColumn(sBlue, 3);
            Grid.SetRow(sBlue, 5);
            ColorOptions.Children.Add(sBlue);
            Label lRed = new Label();
            lRed.Content = "Red: ";
            lRed.Name = "lRed";
            Grid.SetColumn(lRed, 1);
            Grid.SetRow(lRed, 1);
            ColorOptions.Children.Add(lRed);
            Label lGreen = new Label();
            lGreen.Content = "Green: ";
            lGreen.Name = "lGreen";
            Grid.SetColumn(lGreen, 1);
            Grid.SetRow(lGreen, 3);
            ColorOptions.Children.Add(lGreen);
            Label lBlue = new Label();
            lBlue.Content = "Blue: ";
            lBlue.Name = "lBlue";
            Grid.SetColumn(lBlue, 1);
            Grid.SetRow(lBlue, 5);
            ColorOptions.Children.Add(lBlue);
            selectedColorBaner = new Label();
            selectedColorBaner.Content = "";
            selectedColorBaner.Name = "selColor";
            selectedColorBaner.Background = new SolidColorBrush(selectedColor);
            Grid.SetColumn(selectedColorBaner, 1);
            Grid.SetRow(selectedColorBaner, 7);
            ColorOptions.Children.Add(selectedColorBaner);
            Button confirmColor = new Button();
            confirmColor.Content = "Confirm";
            confirmColor.Name = "confirmColor";
            confirmColor.Click += CloseWindow;
            Grid.SetColumn(confirmColor, 3);
            Grid.SetRow(confirmColor, 7);
            ColorOptions.Children.Add(confirmColor);

        }
        private void updateValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            updateColor();
        }
        private void updateColor()
        {
            red = (byte)sRed.Value;
            green = (byte)sGreen.Value;
            blue = (byte)sBlue.Value;
            selectedColor = Color.FromRgb(red, green, blue);
            selectedColorBaner.Background = new SolidColorBrush(selectedColor);
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
