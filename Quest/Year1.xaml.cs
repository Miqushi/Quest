using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Quest
{
    /// <summary>
    /// Логика взаимодействия для Year1.xaml
    /// </summary>
    public partial class Year1 : Window
    {
        public Year1()
        {
            InitializeComponent();
        }
        MainWindow main = new MainWindow();
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
            main.Show();
        }
        int lvl = 0;
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
        private void Damage()
        {
            MessageBox.Show("Ошибка", "Вы ошиблись. Попробуйте еще раз");
            Properties.Settings.Default.hp--;
            switch (Properties.Settings.Default.hp)
            {
                case 2:
                    {
                        hp3.Visibility = Visibility.Hidden;
                    }
                    break;
                case 1:
                    {
                        hp2.Visibility = Visibility.Hidden;
                    }
                    break;
                case 0:
                    {
                        hp1.Visibility = Visibility.Hidden;
                        MessageBox.Show("Конец Игры", "You Died");
                        Properties.Settings.Default.hp = 3;
                        main.Show();
                        Close();
                    }
                    break;
            }
        }
        private void Back(object sender, MouseButtonEventArgs e)
        {
            if (tc.SelectedIndex != 0) tc.SelectedIndex = 1;
        }
        private void Help(object sender, MouseButtonEventArgs e)
        {
            switch (tc.SelectedIndex)
            {
                case 0:
                    MessageBox.Show("1953", "Ответ");
                    break;
                case 2:
                    MessageBox.Show("Мир", "Ответ");
                    break;
                case 3:
                    MessageBox.Show("42. Без суббот и воскресений - значит считать каждые 5 дней в неделю, т.е. лишь 5/7 жизни. Если 5/7 это 30 лет, то верный ответ 30 × 7 / 5 = 42", "Ответ");
                    break;
                case 4:
                    MessageBox.Show("Куб-бук", "Ответ");
                    break;
                case 5:
                    MessageBox.Show("Огонь", "Ответ");
                    break;
                case 6:
                    MessageBox.Show("Человек", "Ответ");
                    break;
                case 7:
                    MessageBox.Show("Какая общая страна у всех этих предметов и событий?", "Ответ");
                    break;
            }
        }
        private void lb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb1.SelectedIndex == 0)
            {
                tc.SelectedIndex = 1;
                //lb1.SetValue(ListBox.SelectedIndexProperty, DependencyProperty.UnsetValue);
            }
            else Damage();
        }
        #region ImgInfo
        private void img1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 2)
            MessageBox.Show(Properties.Resources.img1, "Информация");
        }
        private void img3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 1)
            {
                var animation = new ThicknessAnimation
                {
                    To = new Thickness(0, 50, 550, 150),
                    Duration = TimeSpan.FromSeconds(0.5)
                };
                img3.BeginAnimation(MarginProperty, animation);
                if (img3.Name != "List")
                {
                    tb3.Text = Properties.Resources.ListClick;
                    textBox3.Visibility = Visibility.Visible;
                    otv3.Visibility = Visibility.Visible;
                }
            }
            else MessageBox.Show(Properties.Resources.ListInfo, "Информация");
            
        }
        private void Chest_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount == 1)
            {
                var animation = new ThicknessAnimation
                {
                    To = new Thickness(500, 200, 300, 100),
                    Duration = TimeSpan.FromSeconds(0.5)
                };
                Chest.BeginAnimation(MarginProperty, animation);
                if (Chest.Name != "ChestOpen")
                {
                    tbMath.Text = Properties.Resources.ChestClick;
                    lb4.Visibility = Visibility.Visible;
                }
            }
            else MessageBox.Show(Properties.Resources.ChestInfo,"Информация");  
        }
        #endregion
        #region Riddle
        private void Riddle1()
        {
            string otvet = textBox1.Text.Trim().ToLower();
            if (otvet == "мир")
            {
                tbIst.Text = Properties.Resources.riddle1;
                textBox1.Visibility = Visibility.Collapsed;
                otv1.Visibility = Visibility.Collapsed;
                img1.Visibility = Visibility.Visible;
                lvl += 1;
            }
            else Damage();
        }
        private void Riddle2(object sender, SelectionChangedEventArgs e)
        {
            if (lb4.SelectedIndex == 1)
            {
                tbMath.Text = Properties.Resources.riddle2;
                lb4.Visibility = Visibility.Collapsed;
                Chest.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Img/ChestOpen.png"));
                Chest.Name = "ChestOpen";
                lvl += 1;
            }
            else Damage();
        }
        private void Riddle3()
        {
            string otvet = textBox3.Text.Trim().ToLower();
            if (otvet == "куб-бук" || otvet == "бук-куб")
            {
                tb3.Text = Properties.Resources.riddle3;
                textBox3.Visibility = Visibility.Collapsed;
                otv3.Visibility = Visibility.Collapsed;
                img3.Visibility = Visibility.Visible;
                lvl += 1;
                img3.Name = "List";
            }
            else Damage();
        }
        private void Riddle4()
        {
            string otvet = textBox4.Text.Trim().ToLower();
            if (otvet == "огонь")
            {
                tb4.Text = Properties.Resources.riddle4;
                textBox4.Visibility = Visibility.Collapsed;
                otv4.Visibility = Visibility.Collapsed;
                lvl += 1;
            }
            else Damage();
        }
        private void Riddle5()
        {
            string otvet = textBox5.Text.Trim().ToLower();
            if (otvet == "эдип" || otvet == "человек")
            {
                tb5.Text = Properties.Resources.riddle5;
                textBox5.Visibility = Visibility.Collapsed;
                otv5.Visibility = Visibility.Collapsed;
                lvl += 1;
            }
            else Damage();
        }
        private void Riddle6()
        {
            string otvet = textBox6.Text.Trim().ToLower();
            if (otvet == "греция" || otvet == "древняя греция")
            {
                tb6.Text = Properties.Resources.riddle6;
                textBox6.Visibility = Visibility.Collapsed;
                otv6.Visibility = Visibility.Collapsed;
                next.Visibility = Visibility.Visible;
            }
            else Damage();
        }
        private void otv_Click(object sender, RoutedEventArgs e)
        {
            switch (tc.SelectedIndex)
            {
                case 2:
                    Riddle1();
                    break;
                case 4:
                    Riddle3();
                    break;
                case 5:
                    Riddle4();
                    break;
                case 6:
                    Riddle5();
                    break;
                case 7:
                    Riddle6();
                    break;
            }
        }
        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.YearCount == 0)
                Properties.Settings.Default.YearCount++;
            main.Show();
            Close();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (tc.SelectedIndex)
            {
                case 2:
                    if (e.Key == Key.Enter)
                        Riddle1();
                    break;
                case 4:
                    if (e.Key == Key.Enter)
                        Riddle3();
                    break;
                case 5:
                    if (e.Key == Key.Enter)
                        Riddle4();
                    break;
                case 6:
                    if (e.Key == Key.Enter)
                        Riddle5();
                    break;
                case 7:
                    if (e.Key == Key.Enter)
                        Riddle6();
                    break;
            }
        }
        private void TabItem_GotFocus(object sender, RoutedEventArgs e)
        {
            if (lvl == 5)
            {
                tb6.Text = "Что общего у всех предметов, которые вы нашли?";
                textBox6.Visibility = Visibility.Visible;
                otv6.Visibility = Visibility.Visible;
            }
            else
            {
                tb6.Text = "Приходите позже, когда решите все задания";
            }
        }
        #endregion
        #region MouseClick
        readonly double[,] door =
        {{964/ 1265.6, 1039.2/ 1265.6, 190.4/ 682.4, 533.6/ 682.4 },
        { 748/ 1265.6, 784.8/ 1265.6, 256.8/ 682.4, 468/ 682.4},
        { 668.4/ 1265.6, 696.8/ 1265.6, 290.4/ 682.4, 442.2/ 682.4},
        { 612/ 1265.6, 638.4/ 1265.6, 304/ 682.4, 421.6/ 682.4 },
        { 520/ 1265.6, 559/ 1265.6, 298/ 682.4, 406/ 682.4 },
        { 196.8/ 1265.6, 355.2/ 1265.6, 280/ 682.4, 497.2/ 682.4 },
        };
        readonly double[,] exit = { { 0.7163, 0.8198, 0.1893, 0.8159 },
        { 653.6 / 985.6, 717 / 985.6, 160 / 612.8, 509 / 612.8 },
        { 993.6 / 1265.6, 1108 / 1265.6, 94.4 / 682.4, 466 / 682.4 },
        { 1055 / 1265.6, 1141 / 1265.6, 196 / 682.4, 480.8 / 682.4 },
        { 1039.2 / 1265.6, 1169.2 / 1265.6, 120.8 / 682.4, 526.4 / 682.4 }};
        private void tc_MouseClick(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            //MessageBox.Show("Координата x=" + p.X.ToString() + " y=" + p.Y.ToString(), "Окно");

            //1265.6
            //682.4
            double x = basis.ActualWidth;
            double y = basis.ActualHeight;
            switch (tc.SelectedIndex)
            {
                case 1:
                    {
                        if (p.X > x * door[0, 0] && p.X < x * door[0, 1] &&
                            p.Y > y * door[0, 2] && p.Y < y * door[0, 3])
                        {
                            tc.SelectedIndex = 2;
                        }
                        if (p.X > x * door[1, 0] && p.X < x * door[1, 1] &&
                            p.Y > y * door[1, 2] && p.Y < y * door[1, 3])
                        {
                            tc.SelectedIndex = 3;
                        }
                        if (p.X > x * door[2, 0] && p.X < x * door[2, 1] &&
                            p.Y > y * door[2, 2] && p.Y < y * door[2, 3])
                        {
                            tc.SelectedIndex = 4;
                        }
                        if (p.X > x * door[3, 0] && p.X < x * door[3, 1] &&
                            p.Y > y * door[3, 2] && p.Y < y * door[3, 3])
                        {
                            tc.SelectedIndex = 5;
                        }
                        if (p.X > x * door[4, 0] && p.X < x * door[4, 1] &&
                            p.Y > y * door[4, 2] && p.Y < y * door[4, 3])
                        {
                            tc.SelectedIndex = 6;
                        }
                        if (p.X > x * door[5, 0] && p.X < x * door[5, 1] &&
                            p.Y > y * door[5, 2] && p.Y < y * door[5, 3])
                        {
                            tc.SelectedIndex = 7;
                        }
                    }
                    break;
                case 2:
                    {
                        if (p.X > x * exit[0, 0] && p.X < x * exit[0, 1] &&
                            p.Y > y * exit[0, 2] && p.Y < y * exit[0, 3])
                        {
                            tc.SelectedIndex = 1;
                        }
                    }
                    break;
                case 3:
                    {
                        if (p.X > x * exit[1, 0] && p.X < x * exit[1, 1] &&
                            p.Y > y * exit[1, 2] && p.Y < y * exit[1, 3])
                        {
                            tc.SelectedIndex = 1;
                        }
                    }
                    break;
                case 4:
                    {
                        if (p.X > x * exit[2, 0] && p.X < x * exit[2, 1] &&
                            p.Y > y * exit[2, 2] && p.Y < y * exit[2, 3])
                        {
                            tc.SelectedIndex = 1;
                        }
                    }
                    break;
                case 5:
                    {
                        if (p.X > x * exit[3, 0] && p.X < x * exit[3, 1] &&
                            p.Y > y * exit[3, 2] && p.Y < y * exit[3, 3])
                        {
                            tc.SelectedIndex = 1;
                        }
                    }
                    break;
                case 6:
                    {
                        if (p.X > x * exit[4, 0] && p.X < x * exit[4, 1] &&
                            p.Y > y * exit[4, 2] && p.Y < y * exit[4, 3])
                        {
                            tc.SelectedIndex = 1;
                        }
                    }
                    break;
            }
        }
        private void tc_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            double x = basis.ActualWidth;
            double y = basis.ActualHeight;
            switch (tc.SelectedIndex)
            {
                case 1:
                    {
                        if (p.X > x * door[0, 0] && p.X < x * door[0, 1] &&
                        p.Y > y * door[0, 2] && p.Y < y * door[0, 3] ||
                            p.X > x * door[1, 0] && p.X < x * door[1, 1] &&
                        p.Y > y * door[1, 2] && p.Y < y * door[1, 3] ||
                            p.X > x * door[2, 0] && p.X < x * door[2, 1] &&
                        p.Y > y * door[2, 2] && p.Y < y * door[2, 3] ||
                            p.X > x * door[3, 0] && p.X < x * door[3, 1] &&
                        p.Y > y * door[3, 2] && p.Y < y * door[3, 3] ||
                            p.X > x * door[4, 0] && p.X < x * door[4, 1] &&
                        p.Y > y * door[4, 2] && p.Y < y * door[4, 3] ||
                            p.X > x * door[5, 0] && p.X < x * door[5, 1] &&
                        p.Y > y * door[5, 2] && p.Y < y * door[5, 3])
                        {
                            Cursor = Cursors.Hand;
                        }
                        else
                        {
                            Cursor = Cursors.Arrow;
                        }
                    }
                    break;
                case 2:
                    {
                        if (p.X > x * exit[0, 0] && p.X < x * exit[0, 1] &&
                            p.Y > y * exit[0, 2] && p.Y < y * exit[0, 3])
                        {
                            Cursor = Cursors.Hand;
                        }
                        else
                        {
                            Cursor = Cursors.Arrow;
                        }
                    }
                    break;
                case 3:
                    {
                        if (p.X > x * exit[1, 0] && p.X < x * exit[1, 1] &&
                            p.Y > y * exit[1, 2] && p.Y < y * exit[1, 3])
                        {
                            Cursor = Cursors.Hand;
                        }
                        else
                        {
                            Cursor = Cursors.Arrow;
                        }
                    }
                    break;
                case 4:
                    {
                        if (p.X > x * exit[2, 0] && p.X < x * exit[2, 1] &&
                            p.Y > y * exit[2, 2] && p.Y < y * exit[2, 3])
                        {
                            Cursor = Cursors.Hand;
                        }
                        else
                        {
                            Cursor = Cursors.Arrow;
                        }
                    }
                    break;
                case 5:
                    {
                        if (p.X > x * exit[3, 0] && p.X < x * exit[3, 1] &&
                            p.Y > y * exit[3, 2] && p.Y < y * exit[3, 3])
                        {
                            Cursor = Cursors.Hand;
                        }
                        else
                        {
                            Cursor = Cursors.Arrow;
                        }
                    }
                    break;
                case 6:
                    {
                        if (p.X > x * exit[4, 0] && p.X < x * exit[4, 1] &&
                            p.Y > y * exit[4, 2] && p.Y < y * exit[4, 3])
                        {
                            Cursor = Cursors.Hand;
                        }
                        else
                        {
                            Cursor = Cursors.Arrow;
                        }
                    }
                    break;
                default:
                    Cursor = Cursors.Arrow;
                    break;
            }
        }
        #endregion
        private void PopupBox_Opened(object sender, RoutedEventArgs e)
        {
            if (img1.Visibility == Visibility.Visible)
            {
                img1Popup.Visibility = Visibility.Visible;
            }
            if (Chest.Name == "ChestOpen")
            {
                img2Popup.Visibility = Visibility.Visible;
            }
            if (img3.Name == "List")
            {
                img3Popup.Visibility = Visibility.Visible;
            }
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //1265.6
            //682.4
            double x = basis.ActualWidth;
            double y = basis.ActualHeight;
            img1.Margin = new Thickness(0.0869*x, 0.15 * y, 0.7239 * x, 0.5451* y);
            Chest.Margin = new Thickness(0.561 * x, 0.6726 * y, 0.3430 * x, 0.1085 * y);
            img3.Margin = new Thickness(0.1652 * x, 0.1950 * y, 0.7534 * x, 0.5381 * y);
            img4.Margin = new Thickness(0.4 * x, 0.3 * y, 0.5 * x, 0.5 * y);
            img5.Margin = new Thickness(0.4 * x, 0.3 * y, 0.5 * x, 0.5 * y);
        }
    }
}
