using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using System.Windows.Threading;

using sort;

namespace TeamProgect
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private TimeSpan timeSpan;

        private List<ObservableCollection<double>> TestArrays = new(5) {new(),new(),new(),new(),new()};
        private List<DispatcherTimer> Timers = new(5) { new(), new(), new(), new(), new() };

        public class Data
        {
            public ObservableCollection<double> TestArray1 { get; set; }
            public ObservableCollection<double> TestArray2 { get; set; }
            public ObservableCollection<double> TestArray3 { get; set; }
            public ObservableCollection<double> TestArray4 { get; set; }
            public ObservableCollection<double> TestArray5 { get; set; }

            public Data(ObservableCollection<double> testArray1, ObservableCollection<double> testArray2, ObservableCollection<double> testArray3, ObservableCollection<double> testArray4, ObservableCollection<double> testArray5)
            {
                TestArray1 = testArray1;
                TestArray2 = testArray2;
                TestArray3 = testArray3;
                TestArray4 = testArray4;
                TestArray5 = testArray5;
            }
            public static Data GenRandom(List<ObservableCollection<double>> TestArrays)
            {
                Random random = new Random();
                for (int i = 0; i < 18; i++)
                {
                    double next = random.NextDouble();

                    TestArrays[0].Add(next * 100);
                    TestArrays[1].Add(next * 100);
                    TestArrays[2].Add(next * 100);
                    TestArrays[3].Add(next * 100);
                    TestArrays[4].Add(next * 100);
                }

                //MessageBox.Show(TestArrays[0].ToString() + '\n' + string.Join(", ", TestArrays[0]));

                return new Data(TestArrays[0], TestArrays[1], TestArrays[2], TestArrays[3], TestArrays[4]);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();

            Data data = Data.GenRandom(TestArrays);
            DataContext = data;

        }

        private void InitializeTimer()
        {
            timeSpan = TimeSpan.Zero;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Обновление каждую секунду
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeSpan = timeSpan.Add(TimeSpan.FromSeconds(1));
            //TimerTextBlock.Text = timeSpan.ToString(@"hh\:mm\:ss"); // Форматирование времени
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimazeButton_Click_1(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            //Sort.BubbleSort(TestArrays[0]);
            Stopwatch sw = Stopwatch.StartNew();
            BubbleSort();
            sw.Stop();
            TimerTextBlockBubble.Content = sw.Elapsed;
            //VisualSort.BubbleSort(TestArrays[0]);

            Sort.SelectionSort(TestArrays[1]);
            

        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            TimerTextBlockBubble.Content = null;
            DispatcherTimer timer = Timers[0];
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += new EventHandler((object sender, EventArgs e) => {
                timeSpan = timeSpan.Add(TimeSpan.FromMilliseconds(1));
                TimerTextBlockBubble.Content = timeSpan.ToString(@"mm\:ss\:fffffff"); // Форматирование времени
            });
            timer.Start();
             VisualBubbleSort();
            timer.Stop();
            //MessageBox.Show(TimerTextBlockBubble.Content.ToString() + '\n' + timer.ToString());
        }

        private void ModeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GenerateDataButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //---------------------------------------------------------------------

        async void BubbleSort()
        {
            timeSpan = TimeSpan.Zero;
            DispatcherTimer timer = Timers[0];
            timer.Interval = TimeSpan.FromMicroseconds(1);
            timer.Tick += new EventHandler((object sender, EventArgs e) => {
                timeSpan = timeSpan.Add(TimeSpan.FromMicroseconds(1));
                TimerTextBlockBubble.Content = timeSpan.ToString(@"mm\:ss\:fffffff"); // Форматирование времени
            });
            timer.Start();
            await Dispatcher.BeginInvoke(()=> Sort.BubbleSort(TestArrays[0]));
            //Sort.BubbleSort(TestArrays[0]);
            timer.Stop();
        }
        void VisualBubbleSort()
        {
            VisualSort.BubbleSort(TestArrays[0]);
        }

    }
}
