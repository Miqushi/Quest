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
using System.Windows.Shapes;

namespace Quest
{
    /// <summary>
    /// Логика взаимодействия для Year4.xaml
    /// </summary>
    public partial class Year4 : Window
    {
        public Year4()
        {
            InitializeComponent();
        }
        MainWindow main = new MainWindow();
        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            main.Show();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (Properties.Settings.Default.hp)
            {
                case 3:
                    {
                        hp1.Visibility = Visibility.Visible;
                        hp2.Visibility = Visibility.Visible;
                        hp3.Visibility = Visibility.Visible;
                    }
                    break;
                case 2:
                    {
                        hp1.Visibility = Visibility.Visible;
                        hp2.Visibility = Visibility.Visible;
                    }
                    break;
                case 1:
                    {
                        hp1.Visibility = Visibility.Visible;
                    }
                    break;
            }
        }
        #region
        private int _trueCount = 0;
        private int _count = 0;
        private void Reset()
        {
            if (_count > 3)
            {
                b1.Background = new SolidColorBrush(Colors.Red);
                b2.Background = new SolidColorBrush(Colors.Red);
                b3.Background = new SolidColorBrush(Colors.Red);
                b4.Background = new SolidColorBrush(Colors.Red);
                b5.Background = new SolidColorBrush(Colors.Red);
                b6.Background = new SolidColorBrush(Colors.Red);
                b7.Background = new SolidColorBrush(Colors.Red);
                b8.Background = new SolidColorBrush(Colors.Red);
                b9.Background = new SolidColorBrush(Colors.Red);
                _count = 0;
                _trueCount = 0;
            }
        }
        private void Code_Click(object sender, RoutedEventArgs e)
        {
            if(e.Source == b1)
            {
                b1.Background = new SolidColorBrush(Colors.Green);
                _trueCount++;
                _count++;
                if (_trueCount == 3)
                {
                    MessageBox.Show("sad");
                }
                Reset();
            }
            if (e.Source == b2)
            {
                b2.Background = new SolidColorBrush(Colors.Green);
                _count++;
                Reset();
            }
            if (e.Source == b3)
            {
                b3.Background = new SolidColorBrush(Colors.Green);
                _count++;
                Reset();
            }
            if (e.Source == b4)
            {
                b4.Background = new SolidColorBrush(Colors.Green);
                _count++;
                Reset();
            }
            if (e.Source == b5)
            {
                b5.Background = new SolidColorBrush(Colors.Green);
                _count++;
                Reset();
            }
            if (e.Source == b6)
            {
                b6.Background = new SolidColorBrush(Colors.Green);
                _trueCount++;
                _count++;
                if (_trueCount == 3)
                {
                    MessageBox.Show("sad");
                }
                Reset();
            }
            if (e.Source == b7)
            {
                b7.Background = new SolidColorBrush(Colors.Green);
                _count++;
                Reset();
            }
            if (e.Source == b8)
            {
                b8.Background = new SolidColorBrush(Colors.Green);
                _trueCount++;
                _count++;
                if(_trueCount == 3)
                {
                    MessageBox.Show("sad");
                }
                Reset();
            }
            if (e.Source == b9)
            {
                b9.Background = new SolidColorBrush(Colors.Green);
                _count++;
                Reset();
            }
        }
        #endregion
    }
}
