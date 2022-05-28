﻿using System;
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
        double[] door1 = new double[4] { 0.1126, 0.1441, 0.3623, 0.7963 };
        double[] door2 = new double[4] { 0.2039, 0.2334, 0.4259, 0.7507 };
        double[] door3 = new double[4] { 0.2953, 0.3166, 0.4422, 0.6952 };
        double[] door4 = new double[4] { 0.3521, 0.4200, 0.4439, 0.6665 };
        double[] door5 = new double[4] { 0.6149, 0.7660, 0.4047, 0.7262 };

        private void tabItemHally3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            //MessageBox.Show("Координата x=" + p.X.ToString() + " y=" + p.Y.ToString(), "Окно");
            double x = basis.ActualWidth;
            double y = basis.ActualHeight;
            //985.6
            //612.8

            if (p.X > x * door1[0] && p.X < x * door1[1] &&
                p.Y > y * door1[2] && p.Y < y * door1[3])
            {
                tc.SelectedIndex = 1;
            }
            if (p.X > x * door2[0] && p.X < x * door2[1] &&
                p.Y > y * door2[2] && p.Y < y * door2[3])
            {
                tc.SelectedIndex = 2;
            }
            if (p.X > x * door3[0] && p.X < x * door3[1] &&
                p.Y > y * door3[2] && p.Y < y * door3[3])
            {
                tc.SelectedIndex = 3;
            }
            if (p.X > x * door4[0] && p.X < x * door4[1] &&
                p.Y > y * door4[2] && p.Y < y * door4[3])
            {
                tc.SelectedIndex = 4;
            }
            if (p.X > x * door5[0] && p.X < x * door5[1] &&
                p.Y > y * door5[2] && p.Y < y * door5[3])
            {
                tc.SelectedIndex = 5;
            }
        }

        private void hall_MouseMove(object sender, MouseEventArgs e)
        {
            double x = basis.ActualWidth;
            double y = basis.ActualHeight;
            Point p = e.GetPosition(this);
            if (p.X > x * door1[0] && p.X < x * door1[1] && p.Y > y * door1[2] && p.Y < y * door1[3] ||
            p.X > x * door2[0] && p.X < x * door2[1] && p.Y > y * door2[2] && p.Y < y * door2[3] ||
            p.X > x * door3[0] && p.X < x * door3[1] && p.Y > y * door3[2] && p.Y < y * door3[3] ||
            p.X > x * door4[0] && p.X < x * door4[1] && p.Y > y * door4[2] && p.Y < y * door4[3] ||
            p.X > x * door5[0] && p.X < x * door5[1] &&  p.Y > y * door5[2] && p.Y < y * door5[3]
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
