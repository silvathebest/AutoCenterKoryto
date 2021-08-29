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
    /// Логика взаимодействия для WindowListPrePuchaseWork.xaml
    /// </summary>
    public partial class WindowListPrePuchaseWork : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public WindowListPrePuchaseWork()
        {
            InitializeComponent();
        }

        private void ButtonSaveToWord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSaveToExcel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
