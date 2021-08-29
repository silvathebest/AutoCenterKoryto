using System.Windows;
using Unity;

namespace AutoCenterKorytoView
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

        private void ButtonPrePurchaseWorks_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowPrePurchaseWorks>();
            window.ShowDialog();
        }

        private void ButtonPurchase_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowPurchases>();
            window.ShowDialog();
        }

        private void ButtonClientWishes_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowClientWishes>();
            window.ShowDialog();
        }

        private void ButtonComplectationList_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowComplectationList>();
            window.ShowDialog();
        }

        private void ButtonReport_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowReport>();
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
