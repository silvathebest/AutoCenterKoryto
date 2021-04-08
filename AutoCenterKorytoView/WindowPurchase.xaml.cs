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
    /// Логика взаимодействия для WindowPurchase.xaml
    /// </summary>
    public partial class WindowPurchase : Window
    {
        public WindowPurchase()
        {
            InitializeComponent();
        }

        private void ButtonAddPrePurchaseWorks_Click(object sender, RoutedEventArgs e)
        {
            WindowPrePurchaseWorkSelector window = new WindowPrePurchaseWorkSelector();
            window.ShowDialog();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
