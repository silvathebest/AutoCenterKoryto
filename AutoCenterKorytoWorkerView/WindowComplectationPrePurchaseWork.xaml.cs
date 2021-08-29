using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Unity;


namespace AutoCenterKorytoWorkerView
{
    public partial class WindowComplectationPrePurchaseWork : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private ComplectationLogic _complectationLogic;
        private PrePurchaseWorkLogic _prePurchaseWorkLogic;

        private List<PrePurchaseWorkViewModel> _allWorks;
        private HashSet<PrePurchaseWorkViewModel> _selectedWorks;

        private ComplectationViewModel _currentComplectation;

        public WindowComplectationPrePurchaseWork(ComplectationLogic complectationLogic, PrePurchaseWorkLogic prePurchaseWorkLogic)
        {
            InitializeComponent();
            _complectationLogic = complectationLogic;
            _prePurchaseWorkLogic = prePurchaseWorkLogic;
            _selectedWorks = new HashSet<PrePurchaseWorkViewModel>();
            _allWorks = _prePurchaseWorkLogic.Read(null);
        }

        private void comboBoxComplecation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _currentComplectation = (ComplectationViewModel)comboBoxComplectation.SelectedItem;
            _selectedWorks = _allWorks.Where(aw => _currentComplectation.PrePurchaseWorksIds.Contains(aw.Id)).ToHashSet();
            dataGridSelectedPreWorks.ItemsSource = _selectedWorks;

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            if(_currentComplectation == null)
            {
                MessageBox.Show("Не выбрана комплектация");
                return;
            }
            try
            {
                _complectationLogic.CreateOrUpdate(new ComplectationBindingModel
                {
                    Description = _currentComplectation.Description,
                    Id = _currentComplectation.Id,
                    Name = _currentComplectation.Name,
                    Price = _currentComplectation.Price,
                    WorkerId = _currentComplectation.WorkerId,
                    PrePurcahseWorksIds = _selectedWorks.Select(sw => sw.Id).ToList()
                });
                MessageBox.Show("Успех");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            _selectedWorks.Add((PrePurchaseWorkViewModel)dataGridAvaliblePreWorks.SelectedItem);
            dataGridSelectedPreWorks.Items.Refresh();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            _selectedWorks.Remove((PrePurchaseWorkViewModel)dataGridSelectedPreWorks.SelectedItem);
            dataGridSelectedPreWorks.Items.Refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridAvaliblePreWorks.ItemsSource = _allWorks;
            comboBoxComplectation.ItemsSource = _complectationLogic.Read(null);
        }
    }
}
