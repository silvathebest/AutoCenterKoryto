using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Windows;
using Unity;

namespace AutoCenterKorytoView
{
    public partial class WindowPrePurchaseWorks : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private PrePurchaseWorkLogic _prePurchaseWorkLogic;

        public WindowPrePurchaseWorks(PrePurchaseWorkLogic prePurchaseWorkLogic)
        {
            _prePurchaseWorkLogic = prePurchaseWorkLogic;
            InitializeComponent();
            LoadData();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowPrePurchaseWork window = Container.Resolve<WindowPrePurchaseWork>();
            window.ShowDialog();
            LoadData();
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            WindowPrePurchaseWork window = Container.Resolve<WindowPrePurchaseWork>();
          
            window.PreWorkViewModel = (PrePurchaseWorkViewModel)dataGridPrePurchaseWorks.SelectedItem;
            window.ShowDialog();
            LoadData();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridPrePurchaseWorks.SelectedItems.Count == 1)
                {
                    _prePurchaseWorkLogic.Delete(new PrePurchaseWorkBindingModel { Id = ((PrePurchaseWorkViewModel)dataGridPrePurchaseWorks.SelectedItem).Id, ClientId = App.Client.Id });
                }
                MessageBox.Show("Успешно удалено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            LoadData();
        }

        private void ButtonRef_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var preWorksList = _prePurchaseWorkLogic.Read(null);
                if (preWorksList != null)
                {
                    dataGridPrePurchaseWorks.ItemsSource = preWorksList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
