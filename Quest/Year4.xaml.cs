using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

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
        private void home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tabControl4.SelectedIndex = 0;
        }
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
            if (_count >= 3)
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
            if (e.Source == b1)
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
                if (_trueCount == 3)
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

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (lb1.SelectedIndex)
            {
                case 0:
                    tabControl4.SelectedIndex = 1;
                    break;
                case 1:
                    tabControl4.SelectedIndex = 2;
                    break;
                case 2:
                    tabControl4.SelectedIndex = 3;
                    break;
                case 3:
                    tabControl4.SelectedIndex = 4;
                    break;
            }
            lb1.SetValue(ListBox.SelectedIndexProperty, DependencyProperty.UnsetValue);
        }

        private void Prompt1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Prompt1.Visibility = Visibility.Collapsed;
            Prompt1Pop.Visibility = Visibility.Visible;
        }
    }
}
