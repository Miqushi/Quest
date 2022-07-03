using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Quest
{
    internal class Methods
    {
        public void DealingDamage(Image hp1, Image hp2, Image hp3, Window year1)
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
                        year1.Close();
                    }
                    break;
            }
        }
        public void LivesDisplay(Image hp1, Image hp2, Image hp3)
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
        public void ClickingOnTheDoor(double[,] door, double[,] exit, Point p, double x, double y, TabControl tc, int count, int caseCount)
        {
            if (count == caseCount)
            {
                if (p.X > x * door[0, 0] && p.X < x * door[0, 1] &&
                    p.Y > y * door[0, 2] && p.Y < y * door[0, 3]) 
                    tc.SelectedIndex = caseCount+1;
                if (p.X > x * door[1, 0] && p.X < x * door[1, 1] &&
                    p.Y > y * door[1, 2] && p.Y < y * door[1, 3])
                    tc.SelectedIndex = caseCount + 2;
                if (p.X > x * door[2, 0] && p.X < x * door[2, 1] &&
                    p.Y > y * door[2, 2] && p.Y < y * door[2, 3])
                    tc.SelectedIndex = caseCount + 3;
                if (p.X > x * door[3, 0] && p.X < x * door[3, 1] &&
                    p.Y > y * door[3, 2] && p.Y < y * door[3, 3])
                    tc.SelectedIndex = caseCount + 4;
                if (p.X > x * door[4, 0] && p.X < x * door[4, 1] &&
                    p.Y > y * door[4, 2] && p.Y < y * door[4, 3])
                    tc.SelectedIndex = caseCount + 5;
                if (p.X > x * door[5, 0] && p.X < x * door[5, 1] &&
                    p.Y > y * door[5, 2] && p.Y < y * door[5, 3])
                    tc.SelectedIndex = caseCount + 6;
            }
            if (count == caseCount+1)
            {
                if (p.X > x * exit[0, 0] && p.X < x * exit[0, 1] &&
                    p.Y > y * exit[0, 2] && p.Y < y * exit[0, 3])
                    tc.SelectedIndex = caseCount;
            }
            if (count == caseCount + 2)
            {
                if (p.X > x * exit[1, 0] && p.X < x * exit[1, 1] &&
                    p.Y > y * exit[1, 2] && p.Y < y * exit[1, 3])
                    tc.SelectedIndex = caseCount;
            }
            if (count == caseCount + 3)
            {
                if (p.X > x * exit[2, 0] && p.X < x * exit[2, 1] &&
                            p.Y > y * exit[2, 2] && p.Y < y * exit[2, 3])
                    tc.SelectedIndex = caseCount;
            }
            if (count == caseCount + 4)
            {
                if (p.X > x * exit[3, 0] && p.X < x * exit[3, 1] &&
                            p.Y > y * exit[3, 2] && p.Y < y * exit[3, 3])
                    tc.SelectedIndex = caseCount;
            }
            if (count == caseCount + 5)
            {
                if (p.X > x * exit[4, 0] && p.X < x * exit[4, 1] &&
                            p.Y > y * exit[4, 2] && p.Y < y * exit[4, 3])
                    tc.SelectedIndex = caseCount;
            }
        }
    }
}
