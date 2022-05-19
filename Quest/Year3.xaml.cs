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
    /// Логика взаимодействия для Year3.xaml
    /// </summary>
    public partial class Year3 : Window
    {
        public Year3()
        {
            InitializeComponent();
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
            tc.SelectedIndex = 1;
        }

        private void Help(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            main.Show();
        }

        private void tabItemHally3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            MessageBox.Show("Координата x=" + p.X.ToString() + " y=" + p.Y.ToString(), "Окно");
        }
    }
}
