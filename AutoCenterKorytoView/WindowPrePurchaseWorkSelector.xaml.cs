using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
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
    public partial class WindowPrePurchaseWorkSelector : Window
    {
        public List<PrePurchaseWorkViewModel> AvalibleWorks { get; set; }
        public HashSet<PrePurchaseWorkViewModel> SelectedWorks { get; set; }

        public WindowPrePurchaseWorkSelector(PrePurchaseWorkLogic prePurchaseWorkLogic) 
        {
            InitializeComponent();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            SelectedWorks.Remove((PrePurchaseWorkViewModel)dataGridSelectedPreWorks.SelectedItem);
            dataGridSelectedPreWorks.Items.Refresh();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            SelectedWorks.Add((PrePurchaseWorkViewModel)dataGridAvaliblePreWorks.SelectedItem);
            dataGridSelectedPreWorks.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridAvaliblePreWorks.ItemsSource = AvalibleWorks;
            dataGridSelectedPreWorks.ItemsSource = SelectedWorks;
        }
    }
}
