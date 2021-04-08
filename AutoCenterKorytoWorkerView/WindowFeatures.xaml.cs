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

namespace AutoCenterKorytoWorkerView
{
    /// <summary>
    /// Логика взаимодействия для WindowFeatures.xaml
    /// </summary>
    public partial class WindowFeatures : Window
    {
        public WindowFeatures()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowFeature windowFeature = new WindowFeature();
            windowFeature.ShowDialog();
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
