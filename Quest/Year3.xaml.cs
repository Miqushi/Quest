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
        private void hall_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
        MainWindow main = new MainWindow();
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
        private void Back(object sender, MouseButtonEventArgs e)
        {
            tc.SelectedIndex = 0;
        }
        private void help_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("На этом этаже - без подсказок", "Подсказки");
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            main.Show();
        }

        private void tabItemHally3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            if ((p.X > 110 && p.X < 165) && (p.Y > 221 && p.Y < 485))
            {
                tc.SelectedIndex = 1;
            }
            if ((p.X > 200 && p.X < 230) && (p.Y > 212 && p.Y < 458))
            {
                tc.SelectedIndex = 2;
            }
            if ((p.X > 290 && p.X < 313) && (p.Y > 272 && p.Y < 419))
            {
                tc.SelectedIndex = 3;
            }
            if ((p.X > 347 && p.X < 417) && (p.Y > 273 && p.Y < 413))
            {
                tc.SelectedIndex = 4;
            }
            if ((p.X > 597 && p.X < 751) && (p.Y > 249 && p.Y < 449))
            {
                tc.SelectedIndex = 5;
            }
        }

        private void hall_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            if ((p.X > 110 && p.X < 165) && (p.Y > 221 && p.Y < 485) ||
            (p.X > 200 && p.X < 230) && (p.Y > 212 && p.Y < 458) ||
            (p.X > 290 && p.X < 313) && (p.Y > 272 && p.Y < 419) ||
            (p.X > 347 && p.X < 417) && (p.Y > 273 && p.Y < 413) ||
            (p.X > 597 && p.X < 751) && (p.Y > 249 && p.Y < 449)
            )
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Arrow;
            }
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

        
    }
}
