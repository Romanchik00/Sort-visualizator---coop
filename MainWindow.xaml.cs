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
        private List<ObservableCollection<double>> TestArrays = new(5) {new(),new(),new(),new(),new()};

        bool? isMode;
        bool isGenerate = false;
        bool isLoop = true;

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

        private void Accept() 
        {
            if(isMode is not null && isGenerate)
            {
                StartButton.IsEnabled = true;
                PauseButton.IsEnabled = true;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            StartButton.IsEnabled = false;
            PauseButton.IsEnabled = false;
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
            if (isMode == false)
            {
                BubbleSort();
                SelectionSort();
                InsertionSort();
                MergeSort();
                QuickSort();
            }
            else
            {
                VisualBubbleSort();
                VisualSelectionSort();
                VisualInsertionSort();
                VisualMergeSort();
                VisualQuickSort();
            }
        }

        private async void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            Sort.isLoop = false;
            await Task.Delay(500);
            Sort.isLoop = true;
        }

        private void ModeButton_Click(object sender, RoutedEventArgs e)
        {
            var mode =new Mode();
            var dialog = mode.ShowDialog();
            isMode = dialog;
            Accept();
        }

        private void GenerateDataButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as Data)?.TestArray1.Clear();
            (DataContext as Data)?.TestArray2.Clear();
            (DataContext as Data)?.TestArray3.Clear();
            (DataContext as Data)?.TestArray4.Clear();
            (DataContext as Data)?.TestArray5.Clear();

            if (DataContext is not null)
                DataContext = null;

            Data data = Data.GenRandom(TestArrays);
            DataContext = data;
            isGenerate = true;
            Accept();
        }

        //---------------------------------------------------------------------

        async void BubbleSort()
        {
            await Dispatcher.BeginInvoke(() => {
                Stopwatch sw = Stopwatch.StartNew();
                Sort.BubbleSort(TestArrays[0]);
                sw.Stop();
                TimerTextBlockBubble.Content = sw.Elapsed;
            });
        }

        async void SelectionSort()
        {
            await Dispatcher.BeginInvoke(() => {
                Stopwatch sw = Stopwatch.StartNew();
                Sort.SelectionSort(TestArrays[1]);
                sw.Stop();
                TimerTextBlockSelection.Content = sw.Elapsed;
            });
        }

        async void InsertionSort() 
        {
            await Dispatcher.BeginInvoke(() => {
                Stopwatch sw = Stopwatch.StartNew();
                Sort.InsertionSort(TestArrays[2]);
                sw.Stop();
                TimerTextBlockInsertion.Content = sw.Elapsed;
            });
        }
        async void MergeSort() 
        {
            await Dispatcher.BeginInvoke(() => {
                Stopwatch sw = Stopwatch.StartNew();
                Sort.MergeSort(TestArrays[3], 0, TestArrays[3].Count - 1);
                sw.Stop();
                TimerTextBlockMerge.Content = sw.Elapsed;
            });
        }
        async void QuickSort()
        {
            await Dispatcher.BeginInvoke(() => {
                Stopwatch sw = Stopwatch.StartNew();
                Sort.QuickSort(TestArrays[4], 0 , TestArrays[4].Count - 1);
                sw.Stop();
                TimerTextBlockQuick.Content = sw.Elapsed;
            });
        }

        void VisualBubbleSort()
        {
            VisualSort.BubbleSort(TestArrays[0]);
        }

        void VisualSelectionSort()
        {
            VisualSort.SelectionSort(TestArrays[1]);
        }

        void VisualInsertionSort()
        {
            VisualSort.InsertionSort(TestArrays[2]);
        }
        void VisualMergeSort()
        {
            VisualSort.MergeSort(TestArrays[3], 0, TestArrays[3].Count - 1);
        }
        void VisualQuickSort()
        {
            VisualSort.QuickSort(TestArrays[4], 0, TestArrays[4].Count - 1);
        }

    }
}
