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
    /// Логика взаимодействия для WindowPurchases.xaml
    /// </summary>
    public partial class WindowPurchases : Window
    {
        public WindowPurchases()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowPurchase window = new WindowPurchase();
            window.ShowDialog();
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            WindowPurchase window = new WindowPurchase();
            window.ShowDialog();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRef_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
