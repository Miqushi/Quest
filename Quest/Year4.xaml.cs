using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Quest
{
    /// <summary>
    /// Логика взаимодействия для Year4.xaml
    /// </summary>
    public partial class Year4 : Window
    {
        public Year4()
        {
            InitializeComponent();
        }
        Methods method = new Methods();
        MainWindow main = new MainWindow();
        int puzzleCount;
        private void home_MouseDown(object sender, MouseButtonEventArgs e) => tc.SelectedIndex = 0;
        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            main.Show();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            method.LivesDisplay(hp1, hp2, hp3);
        }
        #region
        private int _trueCount, _count = 0;
        private void Reset()
        {
            if (_trueCount == 3)
            {
                MessageBox.Show("Вы нашли 2 части пазла");
                puzzleCount++;
                Prompt1.Visibility = Visibility.Collapsed;
                Prompt1Pop.Visibility = Visibility.Collapsed;
                Prompt2.Visibility = Visibility.Collapsed;
                Prompt2Pop.Visibility = Visibility.Collapsed;
                Prompt3.Visibility = Visibility.Collapsed;
                Prompt3Pop.Visibility = Visibility.Collapsed; 
            }
            if (_count >= 3)
            {
                b1.Background = new SolidColorBrush(Colors.Red);
                b2.Background = new SolidColorBrush(Colors.Red);
                b3.Background = new SolidColorBrush(Colors.Red);
                b4.Background = new SolidColorBrush(Colors.Red);
                b5.Background = new SolidColorBrush(Colors.Red);
                b6.Background = new SolidColorBrush(Colors.Red);
                b7.Background = new SolidColorBrush(Colors.Red);
                b8.Background = new SolidColorBrush(Colors.Red);
                b9.Background = new SolidColorBrush(Colors.Red);
                _count = 0;
                _trueCount = 0;
            }
        }
        private void Code_Click(object sender, RoutedEventArgs e)
        {
            Button x = (Button)sender;
            x.Background = new SolidColorBrush(Colors.Green);
            if (x.Name == "b1" || x.Name == "b6" || x.Name == "b8")
            {
                _trueCount++;
                _count++;
            }
            else
            {
                _count++;
            }
            Reset();
        }
        private void Prompt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source == Prompt1)
            {
                Prompt1.Visibility = Visibility.Collapsed;
                Prompt1Pop.Visibility = Visibility.Visible;
            }
            if (e.Source == Prompt2)
            {
                Prompt2.Visibility = Visibility.Collapsed;
                Prompt2Pop.Visibility = Visibility.Visible;
            }
            if (e.Source == Prompt3)
            {
                Prompt3.Visibility = Visibility.Collapsed;
                Prompt3Pop.Visibility = Visibility.Visible;
            }
        }
        #endregion
        #region
        Vector _relativeMousePos;
        FrameworkElement _draggedObject;
        void OnDragMove(object sender, MouseEventArgs e)
        {
            UpdatePosition(e);
        }
        void UpdatePosition(MouseEventArgs e)
        {
            var point = e.GetPosition(DragArena);
            var newPos = point - _relativeMousePos;
            Canvas.SetLeft(_draggedObject, newPos.X);
            Canvas.SetTop(_draggedObject, newPos.Y);
        }
        void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            FinishDrag(sender, e);
            Mouse.Capture(null);
        }

        void OnLostCapture(object sender, MouseEventArgs e)
        {
            FinishDrag(sender, e);
        }
        void FinishDrag(object sender, MouseEventArgs e)
        {
            _draggedObject.MouseMove -= OnDragMove;
            _draggedObject.LostMouseCapture -= OnLostCapture;
            _draggedObject.MouseUp -= OnMouseUp;
            UpdatePosition(e);
        }
        private void StartDrag(object sender, MouseButtonEventArgs e)
        {
            _draggedObject = (FrameworkElement)sender;
            _relativeMousePos = e.GetPosition(_draggedObject) - new Point();
            _draggedObject.MouseMove += OnDragMove;
            _draggedObject.LostMouseCapture += OnLostCapture;
            _draggedObject.MouseUp += OnMouseUp;
            Mouse.Capture(_draggedObject);
            
        }
        #endregion
        #region
        readonly double[,] door = { {0.177, 0.2953, 0.3906, 0.8030 },
                            { 0.3876, 0.4521, 0.3845, 0.8269 },
                            { 0.5875, 0.6925, 0.3152, 0.9296 },
                            { 0.7739, 0.9067, 0.2405, 0.9296 },
                            {0,0,0,0 },
                            {0,0,0,0 }
        };
        readonly double[,] exit = { {0.8449, 0.9763, 0.1994, 0.7425 },
                            { 0.8561, 0.9619, 0.1806, 0.5994 },
                            { 0.8949, 0.9620,0.1887, 0.6483 },
                            { 0.8727, 0.99, 0.3235, 0.7683 }
        };
        private void tc_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            double x = basis.ActualWidth;
            double y = basis.ActualHeight;
            int count = tc.SelectedIndex;
            int caseCount = 0;
            method.ClickingOnTheDoor(door, exit, p, x, y, tc,count, caseCount);
            if(tc.SelectedIndex == 2)
            {
                if (p.X > x * 0.071 && p.X < x * 0.4186 &&
                    p.Y > y * 0.6381 && p.Y < y * 0.7994)
                {
                    if (puzzleCount != 2) MessageBox.Show("Найдите все части пазла, чтобы выполнить задание");
                    else tc.SelectedIndex = 5;
                }
            }
        }

        private void tc_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            double x = basis.ActualWidth;
            double y = basis.ActualHeight;
            switch (tc.SelectedIndex)
            {
                case 0:
                    if (p.X > x * door[0, 0] && p.X < x * door[0, 1] &&
                        p.Y > y * door[0, 2] && p.Y < y * door[0, 3] ||
                            p.X > x * door[1, 0] && p.X < x * door[1, 1] &&
                        p.Y > y * door[1, 2] && p.Y < y * door[1, 3] ||
                            p.X > x * door[2, 0] && p.X < x * door[2, 1] &&
                        p.Y > y * door[2, 2] && p.Y < y * door[2, 3] ||
                            p.X > x * door[3, 0] && p.X < x * door[3, 1] &&
                        p.Y > y * door[3, 2] && p.Y < y * door[3, 3])
                        Cursor = Cursors.Hand;
                    else Cursor = Cursors.Arrow;
                    break;
                case 1:
                    if (p.X > x * exit[0, 0] && p.X < x * exit[0, 1] &&
                    p.Y > y * exit[0, 2] && p.Y < y * exit[0, 3])
                        Cursor = Cursors.Hand;
                    else Cursor = Cursors.Arrow;
                    break;
                case 2:
                    if (p.X > x * exit[1, 0] && p.X < x * exit[1, 1] &&
                    p.Y > y * exit[1, 2] && p.Y < y * exit[1, 3]||
                    p.X > x * 0.071 && p.X < x * 0.4186 &&
                    p.Y > y * 0.6381 && p.Y < y * 0.7994)
                        Cursor = Cursors.Hand;
                    else Cursor = Cursors.Arrow;
                    break;
                case 3:
                    if (p.X > x * exit[2, 0] && p.X < x * exit[2, 1] &&
                    p.Y > y * exit[2, 2] && p.Y < y * exit[2, 3])
                        Cursor = Cursors.Hand;
                    else Cursor = Cursors.Arrow;
                    break;
                case 4:
                    if (p.X > x * exit[3, 0] && p.X < x * exit[3, 1] &&
                    p.Y > y * exit[3, 2] && p.Y < y * exit[3, 3])
                        Cursor = Cursors.Hand;
                    else Cursor = Cursors.Arrow;
                    break;
            }
        }
        #endregion
        private int _butCount;
        private void But_LeftClick(object sender, MouseButtonEventArgs e)
        {
            Image x = (Image)sender;
            x.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Img/bg.png"));
            _butCount++;
            switch (_butCount)
            {
                case 1:
                    bb1.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Img/bg.png"));
                    break;
                case 2:
                    bb2.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Img/bg.png"));
                    break;
                case 3:
                    bb3.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Img/bg.png"));
                    break;
                case 4:
                    bb4.Source = BitmapFrame.Create(new Uri(@"pack://application:,,,/Img/bg.png"));
                    imgHelp.Visibility = Visibility.Visible;
                    break;
            }
            
        }
        private int _countClick = 1;
        private void ChangeNumber(object sender, MouseButtonEventArgs e)
        {
            TextBlock tmp = (TextBlock)sender;
            if (_countClick > 4)
                _countClick = 1;
            switch (_countClick)
            {
                case 1:
                    tmp.Text = "1";
                    break;
                case 2:
                    tmp.Text = "2";
                    break;
                case 3:
                    tmp.Text = "3";
                    break;
                case 4:
                    tmp.Text = "4";
                    break;
            }
            _countClick++;
            if(Code1.Text == "4" && Code2.Text == "1" && Code3.Text == "2" && Code4.Text == "3")
            {
                MessageBox.Show("Вы получили две части пазла");
                puzzleCount++;
            }
        }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //1265.6
            //682.4
            double x = basis.ActualWidth;
            double y = basis.ActualHeight;

            bw1.Margin = new Thickness(0.24 * x, 0.015 * y, 0.71 * x, 0.88 * y);
            Prompt1.Margin = new Thickness(0.51 * x, 0.15 * y, 0.43 * x, 0.74 * y);
            Pictures.Margin = new Thickness(0.23 * x, 0.18 * y, 0.70 * x, 0.64 * y);
            Code.Margin = new Thickness(0.23 * x, 0.30 * y, 0.69 * x, 0.50 * y);
            Prompt2.Margin = new Thickness(0.42 * x, 0.15 * y, 0.54 * x, 0.71 * y);
            bw2.Margin = new Thickness(0.68 * x, 0.57 * y, 0.29 * x, 0.25 * y);
            imgHelp.Margin = new Thickness(0.32 * x, 0.25 * y, 0.57 * x, 0.58 * y);
            butPanel.Margin = new Thickness(0.68 * x, 0.36 * y, 0.2 * x, 0.49 * y);
            Prompt3.Margin = new Thickness(0.066 * x, 0.33 * y, 0.899 * x, 0.55 * y);
            bw3.Margin = new Thickness(0.13 * x, 0.58 * y, 0.83 * x, 0.315 * y);
            bw4.Margin = new Thickness(0.12 * x, 0.26 * y, 0.85 * x, 0.63 * y);
            butGrid.Margin = new Thickness(0.67 * x, 0.43 * y, 0.26 * x, 0.40 * y);
        }
    }
}
