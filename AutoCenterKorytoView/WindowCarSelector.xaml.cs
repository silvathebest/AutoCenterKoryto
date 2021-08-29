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
    public partial class WindowCarSelector : Window
    {
        public List<CarViewModel> AvalibleCars { get; set; }
        public HashSet<CarViewModel> SelectedCars { get; set; }

        public WindowCarSelector(CarLogic carLogic)
        {
            InitializeComponent();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            SelectedCars.Remove((CarViewModel)dataGridSelectedCars.SelectedItem);
            dataGridSelectedCars.Items.Refresh();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            SelectedCars.Add((CarViewModel)dataGridAvalibleCars.SelectedItem);
            dataGridSelectedCars.Items.Refresh();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridAvalibleCars.ItemsSource = AvalibleCars;
            dataGridSelectedCars.ItemsSource = SelectedCars;
            
        }
    }
}
