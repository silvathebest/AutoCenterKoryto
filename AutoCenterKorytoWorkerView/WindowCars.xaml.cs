using System.Windows;
using Unity;

namespace AutoCenterKorytoWorkerView
{
    /// <summary>
    /// Логика взаимодействия для Cars.xaml
    /// </summary>
    public partial class WindowCars : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public WindowCars()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowCar windowCar = Container.Resolve<WindowCar>();
            windowCar.ShowDialog();
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRef_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
