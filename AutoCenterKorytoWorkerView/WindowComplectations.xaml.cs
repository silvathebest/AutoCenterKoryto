using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Windows;
using Unity;

namespace AutoCenterKorytoWorkerView
{
    public partial class WindowComplectations : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private ComplectationLogic _complectationLogic;

        public WindowComplectations(ComplectationLogic complectationLogic)
        {
            InitializeComponent();
            _complectationLogic = complectationLogic;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowComplectation windowComplectation = Container.Resolve<WindowComplectation>();
            windowComplectation.ShowDialog();
            LoadData();
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            WindowComplectation windowComplectation = Container.Resolve<WindowComplectation>();
            windowComplectation.Complectation = (ComplectationViewModel)dataGridComplectations.SelectedItem;
            windowComplectation.ShowDialog();
            LoadData();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridComplectations.SelectedItems.Count == 1)
                {
                    _complectationLogic.Delete(new ComplectationBindingModel { Id = ((ComplectationViewModel)dataGridComplectations.SelectedItem).Id, WorkerId = App.Worker.Id });
                    LoadData();
                }
                MessageBox.Show("Успешно удалено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonRef_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void ButtonPrePurchaseWorkBinding_Click(object sender, RoutedEventArgs e)
        {
            var windowComplectationPrePurchaseWork = Container.Resolve<WindowComplectationPrePurchaseWork>();
            windowComplectationPrePurchaseWork.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private  void LoadData()
        {
            try
            {
                var list = _complectationLogic.Read(new ComplectationBindingModel { WorkerId = App.Worker.Id });
                if (list != null)
                {
                    dataGridComplectations.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
            }
        }
    }
}
