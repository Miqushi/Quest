﻿using System.Windows;
using System.Windows.Controls;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public int hp = 3;
        public int lvl = 0;
        public void damage()
        {
            MessageBox.Show("Вы ошиблись. Попробуйте еще раз");
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
                MessageBox.Show("You Died");
                main.Show();
                Close();
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
                    if(tc.SelectedIndex == 7) 
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
        private void img1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("По легенде первое оливковое дерево подарила людям богиня Афина, когда выиграла свой спор с Посейдоном о том, кому быть покровителем Афин. В Греции считалось, что первое оливковое дерево возникло из копья богини Афины, которое она воткнула на Афинском Акрополе.", "Информация");
        }

        private void img2_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("Тетраэдр является треугольной пирамидой при принятии любой из граней за основание. У тетраэдра 4 грани, 4 вершины и 6 рёбер. Тетраэдр, у которого все грани — равносторонние треугольники, называется правильным. Правильный тетраэдр является одним из пяти правильных многогранников.", "Информация");
        }

        private void img3_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show("Прародителем анаграммы однако считают поэта и учёного Ликофрона", "Информация");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string otvet = textBox1.Text.Trim().ToLower();
            if (otvet == "мир")
            {
                tbIst.Text = "Перед вами появляется оливковая ветвь. Вы берете ее и отправляетесь дальше";
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

        private void Help(object sender, RoutedEventArgs e)
        {

            if (tc.SelectedIndex == 2)
            {
                MessageBox.Show("Мир");
            }
            if (tc.SelectedIndex == 3)
            {
                MessageBox.Show("42. Без суббот и воскресений - значит считать каждые 5 дней в неделю, т.е. лишь 5/7 жизни. Если 5/7 это 30 лет, то верный ответ 30 × 7 / 5 = 42 ");
            }
            if (tc.SelectedIndex == 4)
            {
                MessageBox.Show("Куб-бук");
            }
            if (tc.SelectedIndex == 4)
            {
                MessageBox.Show("Куб-бук");
            }
            if (tc.SelectedIndex == 5)
            {
                MessageBox.Show("Вши");
            }
            if (tc.SelectedIndex == 6)
            {
                MessageBox.Show("Человек");
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            tc.SelectedIndex = 1;
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
        private void otv2_Click(object sender, RoutedEventArgs e)
        {
            string otvet = textBox2.Text.Trim().ToLower();
            if (otvet == "куб-бук" || otvet == "бук-куб")
            {
                tb3.Text = "Дверь отворилась. Вы берете листок с анограммой и идете исследовать помещение дальше";
                textBox2.Visibility = Visibility.Collapsed;
                otv2.Visibility = Visibility.Collapsed;
                img3.Visibility = Visibility.Visible;
                lvl += 1;
            }
            else
            {
                damage();
            }
        }

        private void otv5_Click(object sender, RoutedEventArgs e)
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

        private void otv4_Click(object sender, RoutedEventArgs e)
        {
            string otvet = textBox4.Text.Trim().ToLower();
            if (otvet == "вши")
            {
                tb4.Text = "Следующая загадка наиболее известна своей апокрифической причастностью к смерти греческого поэта Гомера, описываемого философами всех времен как «мудрейшего из греков». Гомер отправился на остров Иос, хотя оракул предупреждал о том, что он станет местом его смерти (греки никогда не прислушивались к пророчествам о собственной гибели). Во время своего путешествия по острову Гомер встретил нескольких рыбаков. Он спросил, как идут их дела, и они ответили загадкой:«Что поймали -отбросили, что не словили - сохранили.Что мы поймали?» Не в состоянии отгадать загадку Гомер в конце концов умер на острове, отказываясь покинуть его, пока не найдет ответ.";
                textBox4.Visibility = Visibility.Collapsed;
                otv4.Visibility = Visibility.Collapsed;
                lvl += 1;
            }
            else
            {
                damage();
            }
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
 
        }
    }
}
