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
                    MessageBox.Show("Которые стоят");
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
                    Riddle3();
                    break;
                    case 4:
                    Riddle4();
                    break;
            }
        }
        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (i == 3)
            {
                textBlock4.Text = "Ответьте на вопрос: какие часы показывают верное время только два раза в сутки?";
                responseField4.Visibility = Visibility.Visible;
                Answer4.Visibility = Visibility.Visible;
            }
        }
        #region Riddle
        int i = 0;
        private void Riddle1()
        {
            if (responseField1.Text.Trim().ToLower().IndexOf("тот же") >= 0)
            {
                textBlock1.Text = Properties.Resources.riddle1_2;
                responseField1.Visibility = Visibility.Collapsed;
                Answer1.Visibility = Visibility.Collapsed;
                i++;
            }
            else method.DealingDamage(hp1, hp2, hp3, year);
        }
        private void Riddle2()
        {
            if (responseField2.Text.Trim().ToLower().IndexOf("незаразная")>=0)
            {
                textBlock1.Text = "Это правильный ответ";
                responseField2.Visibility = Visibility.Collapsed;
                Answer2.Visibility = Visibility.Collapsed;
                i++;
            }
            else method.DealingDamage(hp1, hp2, hp3, year);
        }
        private void Riddle3()
        {
            if (responseField3.Text.Trim().ToLower().IndexOf("войны") >= 0)
            {
                textBlock3.Text = Properties.Resources.riddle3_2;
                responseField3.Visibility = Visibility.Collapsed;
                Answer3.Visibility = Visibility.Collapsed;
                i++;
            }
            else method.DealingDamage(hp1, hp2, hp3, year);
        }
        private void Riddle4()
        {
            if (i != 3)
            {
                textBlock4.Text = "Приходите, когда ответите на прошлые задания";
            }
            if (responseField4.Text.Trim().ToLower().IndexOf("стоят") >= 0)
            {
                textBlock4.Text = Properties.Resources.riddle4_2;
                responseField4.Visibility = Visibility.Collapsed;
                Answer4.Visibility = Visibility.Collapsed;
            }
            else method.DealingDamage(hp1, hp2, hp3, year);
        }
        #endregion
        
        #region MouseClick
        readonly double[,] door =
        {{71/ 1265.6, 186/ 1265.6, 99/ 682.4, 626/ 682.4 },
        { 572/ 1265.6, 675/ 1265.6, 259/ 682.4, 412/ 682.4},
        { 861/ 1265.6, 899/ 1265.6, 190/ 682.4, 476/ 682.4},
        { 964/ 1265.6, 1025/ 1265.6, 123/ 682.4, 574/ 682.4 },
        { 0,0,0,0 },
        { 0,0,0,0 },
        };
        readonly double[,] exit = { 
        { 992/ 1265.6, 1149/ 1265.6, 154/ 682.4, 436/ 682.4},
        { 932/ 1265.6, 1144/ 1265.6, 124/ 682.4, 485/ 682.4 },
        { 0,0,0,0 },
        { 1023/ 1265.6, 1185/ 1265.6, 185/ 682.4, 438/ 682.4 },
        { 0,0,0,0 }};
        private void tc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            Point p = e.GetPosition(this);
            double x = basis.ActualWidth;
            double y = basis.ActualHeight;
            int count = tc.SelectedIndex;
            int caseCount = 0;
            method.ClickingOnTheDoor(door, exit, p, x, y, tc, count, caseCount);
        }

        private void tc_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            double x = basis.ActualWidth;
            double y = basis.ActualHeight;
            switch (tc.SelectedIndex)
            {
                case 0:
                    if (p.X > x * door[0, 0] && p.X < x * door[0, 1] &&
                        p.Y > y * door[0, 2] && p.Y < y * door[0, 3] ||
                            p.X > x * door[1, 0] && p.X < x * door[1, 1] &&
                        p.Y > y * door[1, 2] && p.Y < y * door[1, 3] ||
                            p.X > x * door[2, 0] && p.X < x * door[2, 1] &&
                        p.Y > y * door[2, 2] && p.Y < y * door[2, 3] ||
                            p.X > x * door[3, 0] && p.X < x * door[3, 1] &&
                        p.Y > y * door[3, 2] && p.Y < y * door[3, 3] ||
                            p.X > x * door[4, 0] && p.X < x * door[4, 1] &&
                        p.Y > y * door[4, 2] && p.Y < y * door[4, 3])
                    {
                        Cursor = Cursors.Hand;
                    }
                    else
                    {
                        Cursor = Cursors.Arrow;
                    }
                    break;
                case 1:
                    if (p.X > x * exit[0, 0] && p.X < x * exit[0, 1] &&
                    p.Y > y * exit[0, 2] && p.Y < y * exit[0, 3])
                    {
                        Cursor = Cursors.Hand;
                    }
                    else
                    {
                        Cursor = Cursors.Arrow;
                    }
                    break;
                case 3:
                    if (p.X > x * exit[2, 0] && p.X < x * exit[2, 1] &&
                    p.Y > y * exit[2, 2] && p.Y < y * exit[2, 3])
                    {
                        Cursor = Cursors.Hand;
                    }
                    else
                    {
                        Cursor = Cursors.Arrow;
                    }
                    break;
                case 4:
                    if (p.X > x * exit[3, 0] && p.X < x * exit[3, 1] &&
                    p.Y > y * exit[3, 2] && p.Y < y * exit[3, 3])
                    {
                        Cursor = Cursors.Hand;
                    }
                    else
                    {
                        Cursor = Cursors.Arrow;
                    }
                    break;
            }
        }
        #endregion
        
    }
}
