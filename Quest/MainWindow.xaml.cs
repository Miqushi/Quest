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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    static class year
    {
        public static int x { get; set; } = 0;
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void curs1_Click(object sender, RoutedEventArgs e)
        {
            Year1 y1 = new Year1();
            y1.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        { 
            if(year.x >= 1)
            {
                curs2.IsEnabled = true;
            }
        }
    }
}
