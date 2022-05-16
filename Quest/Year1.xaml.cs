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
            main.Show();
        }
        public int hp = 3;
        public int lvl = 0;
        public void damage()
        {
            MessageBox.Show("Ошибка", "Вы ошиблись. Попробуйте еще раз");
            hp -= 1;
            if (hp == 2)
            {
                hp3.Opacity = 0;
            }
            if (hp == 1)
            {
                hp2.Opacity = 0;
            }
            if (hp == 0)
            {
                hp1.Opacity = 0;
                MessageBox.Show("Конец Игры", "You Died");
                main.Show();
                Close();
            }
        }
        private void Back(object sender, MouseButtonEventArgs e)
        {
            tc.SelectedIndex = 1;
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
            }
            else
            {
                damage();
            }
        }

        private void lb2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                if (lb2.SelectedIndex == i)
                {
                    tc.SelectedIndex = i + 2;
                    if (tc.SelectedIndex == 7)
                    {
                        if (lvl == 5)
                        {
                            tb6.Text = "Что общего у всех предметов, которые вы нашли?";
                            textBox6.Visibility = Visibility.Visible;
                            otv6.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            tb6.Text = "Приходите позже, когда ответите на все загадки";
                        }
                    }
                }
            }
            lb2.SetValue(ListBox.SelectedIndexProperty, DependencyProperty.UnsetValue);
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
                tbIst.Text = "Перед вами появляется оливковая ветвь. Вы берете ее и идете дальше";
                textBox1.Visibility = Visibility.Collapsed;
                otv1.Visibility = Visibility.Collapsed;
                img1.Visibility = Visibility.Visible;
                lvl += 1;
            }
            else
            {
                damage();
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
                tbMath.Text = "Сейф отворяется. Внутри него лежал тетраэдр. Вы берете его и отправляетесь исследовать другие комнаты";
                lb4.Visibility = Visibility.Collapsed;
                img2.Visibility = Visibility.Visible;
                lvl += 1;
            }
            else
            {
                damage();
            }
        }
        private void Riddle3()
        {
            string otvet = textBox2.Text.Trim().ToLower();
            if (otvet == "куб-бук" || otvet == "бук-куб")
            {
                tb3.Text = "Дверь отворилась. Вы берете листок с анограммой и шагаете исследовать помещения дальше";
                textBox2.Visibility = Visibility.Collapsed;
                otv3.Visibility = Visibility.Collapsed;
                img3.Visibility = Visibility.Visible;
                lvl += 1;
            }
            else
            {
                damage();
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
                tb4.Text = "По древнейшей версии мифа, Прометей похитил огонь у Гефеста, унёс с Олимпа и передал его людям. Он совершил это, скрыв искру в полом стебле тростника (нарфекс) и показал людям, как его сохранять, присыпая золой. В истолковании, он изобрёл «огневые палочки», от которых загорается огонь. В наказание Зевс направит людям первую женщину — Пандору. По версии мифа, заполучить огонь Прометею помогла Афина.";
                img4.Visibility = Visibility.Visible;
                textBox4.Visibility = Visibility.Collapsed;
                otv4.Visibility = Visibility.Collapsed;
                lvl += 1;
            }
            else
            {
                damage();
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
                tb5.Text = "Вы видете картину, а рядом с ней подпись: На картине изображена встреча Эдипа со Сфинксом на пути между Фивами и Дельфами. Эдип должен был правильно ответить на загадку Сфинкса, чтобы пройти. Неудача означала для него смерть и гибель осаждённых фиванцев. Загадка заключалась в следующем: «кто ходит на четырёх ногах утром, на двух днём и на трёх ночью?». Эдип ответил: «Человек: в младенчестве он ползает на четвереньках; во взрослом возрасте он ходит на двух ногах и в старости он использует посох». По преданию существует и иной ответ на загадку. И он был сам Эдип.";
                img5.Visibility = Visibility.Visible;
                textBox5.Visibility = Visibility.Collapsed;
                otv5.Visibility = Visibility.Collapsed;
                lvl += 1;
            }
            else
            {
                damage();
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
                tb6.Text = "Этот ответ оказывается правильным. Дверь открываеся и вы проходите на второй этаж";
                textBox6.Visibility = Visibility.Collapsed;
                otv6.Visibility = Visibility.Collapsed;
                next.Visibility = Visibility.Visible;
            }
            else
            {
                damage();
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.YearCount = +1;
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


        private void hall_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Point p = e.GetPosition(this);

            if (basis.ActualHeight > 1000 && basis.ActualWidth > 1900)
            {
                if ((p.X > 1302 && p.X < 1415) && (p.Y > 383 && p.Y < 843))
                {
                    MessageBox.Show("1");
                }

            }
            else
            {
                if ((p.X > 565 && p.X < 620) && (p.Y > 205 && p.Y < 419))
                {
                    MessageBox.Show("1", "1");
                }
                if ((p.X > 432 && p.X < 458) && (p.Y > 241 && p.Y < 371))
                {
                    MessageBox.Show("2", "2");
                }
                if ((p.X > 377 && p.X < 401) && (p.Y > 269 && p.Y < 368))
                {
                    MessageBox.Show("3", "3");
                }
                if ((p.X > 349 && p.X < 365) && (p.Y > 271 && p.Y < 357))
                {
                    MessageBox.Show("4", "4");
                }
                if ((p.X > 258 && p.X < 324) && (p.Y > 271 && p.Y < 348))
                {
                    MessageBox.Show("5", "5");
                }
                if ((p.X > 72 && p.X < 172) && (p.Y > 259 && p.Y < 389))
                {
                    MessageBox.Show("6", "6");
                }

            }
            //MessageBox.Show("Разрешение экрана: " + basis.ActualHeight.ToString() + " X " + basis.ActualWidth.ToString());
            //MessageBox.Show("Координата x=" + p.X.ToString() + " y=" + p.Y.ToString(), "Окно");
        }

        private void hall_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
