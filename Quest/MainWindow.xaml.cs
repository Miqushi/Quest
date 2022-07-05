using System.Windows;

namespace Quest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Methods method = new Methods();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void curs1_Click(object sender, RoutedEventArgs e)
        {
            Year1 y1 = new Year1();
            y1.year = y1;
            y1.Show();
            Close();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.YearCount > 0)
            {
                curs2.IsEnabled = true;
            }
            if (Properties.Settings.Default.YearCount > 1)
            {
                curs3.IsEnabled = true;
            }
            if (Properties.Settings.Default.YearCount > 2)
            {
                curs4.IsEnabled = true;
            }
            method.LivesDisplay(hp1, hp2, hp3);
        }

        private void curs2_Click(object sender, RoutedEventArgs e)
        {
            Year2 y2 = new Year2();
            y2.year = y2;
            y2.Show();
            Close();
        }

        private void curs3_Click(object sender, RoutedEventArgs e)
        {
            Year3 y3 = new Year3();
            y3.year = y3;
            y3.Show();
            Close();
        }

        private void curs4_Click(object sender, RoutedEventArgs e)
        {
            Year4 y4 = new Year4();
            y4.year = y4;
            y4.Show();
            Close();
        }

        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MessageBox.Show(Properties.Resources.Reference,"Справка");
        }
    }
}
