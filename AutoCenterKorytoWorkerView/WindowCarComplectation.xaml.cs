using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using Unity;

namespace AutoCenterKorytoWorkerView
{
    public partial class WindowCarComplectation : Window
    {
        public List<ComplectationViewModel> AvalibleComplectations { get; set; }
        public ComplectationViewModel SelectedComplectation { get; set; }

        public WindowCarComplectation()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SelectedComplectation = (ComplectationViewModel)comboBoxComplectations.SelectedItem;
                DialogResult = true;
            }
            catch (Exception ex)
            {
                DialogResult = false;
                MessageBox.Show(ex.Message);
            }
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxComplectations.ItemsSource = AvalibleComplectations;
            if (SelectedComplectation == null)
                comboBoxComplectations.SelectedItem = AvalibleComplectations?[0];
            else
                comboBoxComplectations.SelectedItem = SelectedComplectation;
            comboBoxComplectations.Items.Refresh();
        }
    }
}
