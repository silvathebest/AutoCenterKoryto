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

namespace AutoCenterKorytoWorkerView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCar_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowCars();
            window.ShowDialog();
        }

        private void ButtonComplectation_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowComplectations();
            window.ShowDialog();
        }

        private void ButtonFeature_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowFeatures();
            window.ShowDialog();
        }

        private void ButtonListPrePuchaseWork_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowListPrePuchaseWork();
            window.ShowDialog();
        }

        private void ButtonReport_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowReportComplectation();
            window.ShowDialog();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            var window = new WindowLogin();
            window.Show();
            Close();
        }
    }
}
