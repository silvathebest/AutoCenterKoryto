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

namespace AutoCenterKorytoView
{
    /// <summary>
    /// Логика взаимодействия для WindowPrePurchaseWorks.xaml
    /// </summary>
    public partial class WindowPrePurchaseWorks : Window
    {
        public WindowPrePurchaseWorks()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowPrePurchaseWork window = new WindowPrePurchaseWork();
            window.ShowDialog();
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            WindowPrePurchaseWork window = new WindowPrePurchaseWork();
            window.ShowDialog();
        }
    }
}
