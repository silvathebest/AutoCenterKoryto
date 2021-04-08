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

namespace AutoCenterKorytoView
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

        private void ButtonPrePurchaseWorks_Click(object sender, RoutedEventArgs e)
        {
            WindowPrePurchaseWorks window = new WindowPrePurchaseWorks();
            window.ShowDialog();
        }

        private void ButtonPurchase_Click(object sender, RoutedEventArgs e)
        {
            WindowPurchases window = new WindowPurchases();
            window.ShowDialog();
        }

        private void ButtonClientWishes_Click(object sender, RoutedEventArgs e)
        {
            WindowClientWishes window = new WindowClientWishes();
            window.ShowDialog();
        }

        private void ButtonComplectationList_Click(object sender, RoutedEventArgs e)
        {
            WindowComplectationList window = new WindowComplectationList();
            window.ShowDialog();
        }

        private void ButtonReport_Click(object sender, RoutedEventArgs e)
        {
            WindowReport window = new WindowReport();
            window.ShowDialog();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
