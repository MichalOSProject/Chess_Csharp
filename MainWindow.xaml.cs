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

namespace Chess
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            int ID = 0;
            bool Row = false;
            {
                for (int j = 0; j <= 7; j++)
                {
                    for (int k = 0; k <= 7; k++)
                    {

                        Button BoardSpace = new Button();
                        bool evenRow = (ID / 8) % 2 == 0;
                        bool evenColumn = ID % 2 == 0;
                        if (evenRow == evenColumn)
                        {
                            BoardSpace.Background = Brushes.White;

                        }
                        else {
                            BoardSpace.Background = Brushes.Black;
                        }

                        BoardSpace.Name = "Bababab" + ID;
                        BoardSpace.Content = "B" + ID;
                        BoardSpace.Click += Button_Click;
                        Grid.SetColumn(BoardSpace, k);
                        Grid.SetRow(BoardSpace, j);
                        SandBox.Children.Add(BoardSpace);
                        ID++;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HADFASDASDASdasd");
        }
    }
}
