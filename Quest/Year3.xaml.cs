using System;
using System.Windows;
using System.Windows.Input;

namespace Quest
{
    /// <summary>
    /// Логика взаимодействия для Year3.xaml
    /// </summary>
    public partial class Year3 : Window
    {
        public Year3()
        {
            InitializeComponent();
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

        readonly MainWindow main = new MainWindow();
        public void Damage()
        {
            MessageBox.Show("Ошибка", "Вы ошиблись. Попробуйте еще раз");
            Properties.Settings.Default.hp--;
            if (Properties.Settings.Default.hp == 2)
            {
                hp3.Opacity = 0;
            }
            if (Properties.Settings.Default.hp == 1)
            {
                hp2.Opacity = 0;
            }
            if (Properties.Settings.Default.hp == 0)
            {
                hp1.Opacity = 0;
                MessageBox.Show("Конец Игры", "You Died");
                Properties.Settings.Default.hp = 3;
                main.Show();
                Close();
            }
        }
        private void Back(object sender, MouseButtonEventArgs e) => tc.SelectedIndex = 0;
        private void help_MouseDown(object sender, MouseButtonEventArgs e)
        {
            switch (tc.SelectedIndex)
            {
                case 1:
                    MessageBox.Show("Это шифр Цезаря. Число сдвига: номер этого императора");
                    break;
                case 2:
                    MessageBox.Show("Это книжный (Библейский) шифр. 1-ая цифра - глава. 2-ая цифра -  абзац 3-ая цифра - предложение 4-ая цифра -  слово");
                    break;
                case 3:
                    MessageBox.Show("Это морзянка (Код Морзе)");
                    break;
                case 4:
                    MessageBox.Show("Подсказка в предыдущей комнате (с морзянкой)");
                    break;
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            main.Show();
        }
        private void Riddle5()
        {
            string otvet = textBox5.Text.Trim().ToLower();
            if (otvet == "граммофон")
            {
                textBlock5.Text = "Это правильный ответ и вы проходите дальше";
                textBox5.Visibility = Visibility.Collapsed;
                otv5.Visibility = Visibility.Collapsed;
                next.Visibility = Visibility.Visible;
            }
            else
            {
                Damage();
            }
        }
        private void otv5_Click(object sender, RoutedEventArgs e)
        {
            Riddle5();
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (tc.SelectedIndex)
            {
                case 5:
                    if (e.Key == Key.Enter)
                    {
                        Riddle5();
                    }
                    break;

            }
        }
        private void next_Click(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.YearCount == 2)
            {
                Properties.Settings.Default.YearCount++;
            }
            main.Show();
            Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double x = basis.ActualWidth;
            double y = basis.ActualHeight;
            Caesar.Margin = new Thickness(0.38 * x, 0.45 * y, 0.50 * x, 0.42 * y);
            Book.Margin = new Thickness(0.58 * x, 0.65 * y, 0.30 * x, 0.16 * y);
            Morse1.Margin = new Thickness(0.03 * x, 0.18 * y, 0.38 * x, 0.54 * y);
            Morse2.Margin   = new Thickness(0.02 * x, 0.46 * y, 0.68 * x, 0.37 * y);
        }
        #region
        readonly double[,] door = { {0.1126, 0.1441, 0.3623, 0.7963 },
                            { 0.2039, 0.2334, 0.4259, 0.7507 },
                            { 0.2907, 0.3166, 0.4422, 0.6952 },
                            { 0.3521, 0.4200, 0.4439, 0.6665 },
                            { 0.6149, 0.7660, 0.4047, 0.7262 }
        };
        readonly double[,] exit = { {0.8293, 0.9247, 0.4009,0.9297 },
                            { 0, 0, 0, 0 },
                            { 0.5764, 0.6687, 0.2878, 0.6541 },
                            { 0.4959, 0.6203, 0.3094, 0.8159 },
                            { 0.6149, 0.7660, 0.4047, 0.7262 }
        };
        private void tc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            double x = basis.ActualWidth;
            double y = basis.ActualHeight;
            switch (tc.SelectedIndex)
            {
                case 0:
                    if (p.X > x * door[0, 0] && p.X < x * door[0, 1] &&
                    p.Y > y * door[0, 2] && p.Y < y * door[0, 3])
                    {
                        tc.SelectedIndex = 1;
                    }
                    if (p.X > x * door[1, 0] && p.X < x * door[1, 1] &&
                        p.Y > y * door[1, 2] && p.Y < y * door[1, 3])
                    {
                        tc.SelectedIndex = 2;
                    }
                    if (p.X > x * door[2, 0] && p.X < x * door[2, 1] &&
                        p.Y > y * door[2, 2] && p.Y < y * door[2, 3])
                    {
                        tc.SelectedIndex = 3;
                    }
                    if (p.X > x * door[3, 0] && p.X < x * door[3, 1] &&
                        p.Y > y * door[3, 2] && p.Y < y * door[3, 3])
                    {
                        tc.SelectedIndex = 4;
                    }
                    if (p.X > x * door[4, 0] && p.X < x * door[4, 1] &&
                        p.Y > y * door[4, 2] && p.Y < y * door[4, 3])
                    {
                        tc.SelectedIndex = 5;
                    }
                    break;
                case 1:
                    if (p.X > x * exit[0, 0] && p.X < x * exit[0, 1] &&
                    p.Y > y * exit[0, 2] && p.Y < y * exit[0, 3])
                    {
                        tc.SelectedIndex = 0;
                    }
                    break;
                case 3:
                    if (p.X > x * exit[2, 0] && p.X < x * exit[2, 1] &&
                    p.Y > y * exit[2, 2] && p.Y < y * exit[2, 3])
                    {
                        tc.SelectedIndex = 0;
                    }
                    break;
                case 4:
                    if (p.X > x * exit[3, 0] && p.X < x * exit[3, 1] &&
                    p.Y > y * exit[3, 2] && p.Y < y * exit[3, 3])
                    {
                        tc.SelectedIndex = 0;
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
