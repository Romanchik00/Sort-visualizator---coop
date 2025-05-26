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

namespace TeamProgect
{
    /// <summary>
    /// Логика взаимодействия для SPEED.xaml
    /// </summary>
    public partial class Mode : Window
    {
        public Mode()
        {
            InitializeComponent();
        }

        private void SpeedButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void VisualButton_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
