using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Quest
{
    internal class Damage
    {
        MainWindow main = new MainWindow();
        public void DealingDamage(Image hp1, Image hp2, Image hp3, Year1 year1)
        {
            MessageBox.Show("Ошибка", "Вы ошиблись. Попробуйте еще раз");
            Properties.Settings.Default.hp--;
            switch (Properties.Settings.Default.hp)
            {
                case 2:
                        hp3.Visibility = Visibility.Hidden;
                    break;
                case 1:
                        hp2.Visibility = Visibility.Hidden;
                    break;
                case 0:
                    {
                        hp1.Visibility = Visibility.Hidden;
                        MessageBox.Show("Конец Игры", "You Died");
                        Properties.Settings.Default.hp = 3;
                        main.Show();
                    }
                    break;
            }
        }
    }
}
