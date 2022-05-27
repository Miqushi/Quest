using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        public int lvl = 0;
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
        public void Damage()
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
            if (tc.SelectedIndex != 0)
            {
                tc.SelectedIndex = 1;
            }
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
            else
            {
                Damage();
            }
        }
        private void img1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("По легенде первое оливковое дерево подарила людям богиня Афина, когда выиграла свой спор с Посейдоном о том, кому быть покровителем Афин. В Греции считалось, что первое оливковое дерево возникло из копья богини Афины, которое она воткнула на Афинском Акрополе.", "Информация");
        }

        private void img2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Тетраэдр является треугольной пирамидой при принятии любой из граней за основание. У тетраэдра 4 грани, 4 вершины и 6 рёбер. Тетраэдр, у которого все грани — равносторонние треугольники, называется правильным. Правильный тетраэдр является одним из пяти правильных многогранников.", "Информация");
        }

        private void img3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Прародителем анаграммы однако считают поэта и учёного Ликофрона", "Информация");
        }
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
            else
            {
                Damage();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Riddle1();
        }
        private void lb4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lb4.SelectedIndex == 1)
            {
                tbMath.Text = Properties.Resources.riddle2;
                lb4.Visibility = Visibility.Collapsed;
                img2.Visibility = Visibility.Visible;
                lvl += 1;
            }
            else
            {
                Damage();
            }
        }
        private void Riddle3()
        {
            string otvet = textBox2.Text.Trim().ToLower();
            if (otvet == "куб-бук" || otvet == "бук-куб")
            {
                tb3.Text = Properties.Resources.riddle3;
                textBox2.Visibility = Visibility.Collapsed;
                otv3.Visibility = Visibility.Collapsed;
                img3.Visibility = Visibility.Visible;
                lvl += 1;
            }
            else
            {
                Damage();
            }
        }
        private void otv3_Click(object sender, RoutedEventArgs e)
        {
            Riddle3();
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
            else
            {
                Damage();
            }
        }
        private void otv4_Click(object sender, RoutedEventArgs e)
        {
            Riddle4();
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
            else
            {
                Damage();
            }
        }
        private void otv5_Click(object sender, RoutedEventArgs e)
        {
            Riddle5();
        }
        private void otv6_Click(object sender, RoutedEventArgs e)
        {
            string otvet = textBox6.Text.Trim().ToLower();
            if (otvet == "греция" || otvet == "древняя греция")
            {
                tb6.Text = Properties.Resources.riddle6;
                textBox6.Visibility = Visibility.Collapsed;
                otv6.Visibility = Visibility.Collapsed;
                next.Visibility = Visibility.Visible;
            }
            else
            {
                Damage();
            }
        }
        private void next_Click(object sender, RoutedEventArgs e)
        {
            if(Properties.Settings.Default.YearCount == 0)
            {
                Properties.Settings.Default.YearCount++;
            }
            main.Show();
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (tc.SelectedIndex)
            {
                case 2:
                    if (e.Key == Key.Enter)
                    {
                        Riddle1();
                    }
                    break;
                case 4:
                    if (e.Key == Key.Enter)
                    {
                        Riddle3();
                    }
                    break;
                case 5:
                    if (e.Key == Key.Enter)
                    {
                        Riddle4();
                    }
                    break;
                case 6:
                    if (e.Key == Key.Enter)
                    {
                        Riddle5();
                    }
                    break;
            }
        }

        private void hall_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);

            //if ((p.X > 668 && p.X < 734) && (p.Y > 250 && p.Y < 500) ||
            //(p.X > 524 && p.X < 540) && (p.Y > 297 && p.Y < 450) ||
            //(p.X > 450 && p.X < 473) && (p.Y > 317 && p.Y < 432) ||
            //(p.X > 413 && p.X < 430) && (p.Y > 322 && p.Y < 422) ||
            //(p.X > 338 && p.X < 386) && (p.Y > 319 && p.Y < 418) ||
            //(p.X > 79 && p.X < 201) && (p.Y > 306 && p.Y < 460)
            //)
            //{
            //    Cursor = Cursors.Hand;
            //}
            //else
            //{
            //    Cursor = Cursors.Arrow;
            //}

        }

        private void tabItemHall_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            MessageBox.Show("Координата x=" + p.X.ToString() + " y=" + p.Y.ToString(), "Окно");
            double[] door1 = new double[4] { 0.6842532467532468, 0.7451298701298701, 0.3994778067885117, 0.8133159268929504 };
            double[] door2 = new double[4] { 0.5332792207792208, 0.549512987012987, 0.4843342036553525, 0.7428198433420366 };
            double[] door3 = new double[4] { 0.4594155844155844, 0.4805194805194805, 0.5169712793733681, 0.706266318537859 };
            double[] door4 = new double[4] {0.4188311688311688,0.4342532467532468,0.5274151436031332,0.695822454308094 };
            //985.6
            //612.8
            if (p.X > basis.ActualWidth * door1[0] && p.X < basis.ActualWidth * door1[1] &&
                p.Y > basis.ActualHeight * door1[2] && p.Y < basis.ActualHeight * door1[3])
            {
                //tc.SelectedIndex = 2;
            }
            if (p.X > basis.ActualWidth * door2[0] && p.X < basis.ActualWidth * door2[1] &&
                p.Y > basis.ActualHeight * door2[2] && p.Y < basis.ActualHeight * door2[3])
            {
                //tc.SelectedIndex = 3;
            }
            if (p.X > basis.ActualWidth * door3[0] && p.X < basis.ActualWidth * door3[1] &&
                p.Y > basis.ActualHeight * door3[2] && p.Y < basis.ActualHeight * door3[3])
            {
                //MessageBox.Show("yep");
                //tc.SelectedIndex = 4;
            }
            if (p.X > basis.ActualWidth * door4[0] && p.X < basis.ActualWidth * door4[1] &&
                p.Y > basis.ActualHeight * door4[2] && p.Y < basis.ActualHeight * door4[3])
            {
                MessageBox.Show("asd");
                //tc.SelectedIndex = 5;
            }
            //if ((p.X > 338 && p.X < 386) && (p.Y > 319 && p.Y < 418))
            //{
            //    tc.SelectedIndex = 6;
            //}
            //if ((p.X > 79 && p.X < 201) && (p.Y > 306 && p.Y < 460))
            //{
            //    tc.SelectedIndex = 7;
            //}

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

        private void hall_MouseLeave(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Arrow;
        } 
    }
}
