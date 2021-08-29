using AutoCenterKorytoBusinessLogic.BusinessLogic;
using AutoCenterKorytoBusinessLogic.HelperModels;
using System;
using System.Configuration;
using System.Windows;
using Unity;

namespace AutoCenterKorytoWorkerView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonCar_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowCars>();
            window.ShowDialog();
        }

        private void ButtonComplectation_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowComplectations>();
            window.ShowDialog();
        }

        private void ButtonFeature_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowFeatures>();
            window.ShowDialog();
        }

        private void ButtonListPrePuchaseWork_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowListPrePuchaseWork>();
            window.ShowDialog();
        }

        private void ButtonReport_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowReportComplectation>();
            window.ShowDialog();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowLogin>();
            window.Show();
            Close();
        }
    }
}
