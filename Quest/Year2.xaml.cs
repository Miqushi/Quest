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
    /// Логика взаимодействия для Year2.xaml
    /// </summary>
    public partial class Year2 : Window
    {
        public Window year;
        Methods method = new Methods();
        public Year2()
        {
            InitializeComponent();
        }
        MainWindow main = new MainWindow();
        private void Back(object sender, MouseButtonEventArgs e) => tc.SelectedIndex = 0;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            method.LivesDisplay(hp1, hp2, hp3);
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            main.Show();
        }

        private void help_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (tc.SelectedIndex)
            {
                case 1:
                    MessageBox.Show("Это один и тот же человек");
                    break;
                case 2:
                    MessageBox.Show("Эта болезнь незаразная");
                    break;
                case 3:
                    MessageBox.Show("Войны");
                    break;
                case 4:
                    MessageBox.Show("");
                    break;
            }
        }

        private void CheckAnswer(object sender, RoutedEventArgs e)
        {
            switch (tc.SelectedIndex)
            {
                case 1:
                    Riddle1();
                    break;
                   case 2:
                    Riddle2();
                    break;
                    case 3:
                    break;
                    case 4:
                    break;
            }
        }
        private void Riddle1()
        {
            if (responseField1.Text.Trim().ToLower().IndexOf("тот же") >= 0)
            {
                textBlock1.Text = Properties.Resources.riddle12;
                responseField1.Visibility = Visibility.Collapsed;
                Answer1.Visibility = Visibility.Collapsed;
            }
            else method.DealingDamage(hp1, hp2, hp3, year);
        }
        private void Riddle2()
        {
            if (responseField2.Text.Trim().ToLower().IndexOf("незаразная")>=0)
            {
                textBlock2.Text = Properties.Resources.riddle22;
                responseField2.Visibility = Visibility.Collapsed;
                Answer2.Visibility = Visibility.Collapsed;
            }
            else method.DealingDamage(hp1, hp2, hp3, year);
        }
        private void Riddle3()
        {
            if (responseField3.Text.Trim().ToLower().IndexOf("войны") >= 0)
            {
                textBlock3.Text = Properties.Resources.riddle32;
                responseField3.Visibility = Visibility.Collapsed;
                Answer3.Visibility = Visibility.Collapsed;
            }
            else method.DealingDamage(hp1, hp2, hp3, year);
        }

        
    }
}
