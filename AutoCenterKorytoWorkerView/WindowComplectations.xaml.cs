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
using Unity;

namespace AutoCenterKorytoWorkerView
{
    /// <summary>
    /// Логика взаимодействия для WindowComplectations.xaml
    /// </summary>
    public partial class WindowComplectations : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public WindowComplectations()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowComplectation windowComplectation = Container.Resolve<WindowComplectation>();
            windowComplectation.ShowDialog();
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            WindowComplectation windowComplectation = Container.Resolve<WindowComplectation>();
            windowComplectation.ShowDialog();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRef_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPrePurchaseWorkBinding_Click(object sender, RoutedEventArgs e)
        {
            var windowComplectationPrePurchaseWork = Container.Resolve<WindowComplectationPrePurchaseWork>();
            windowComplectationPrePurchaseWork.ShowDialog();
        }
    }
}
