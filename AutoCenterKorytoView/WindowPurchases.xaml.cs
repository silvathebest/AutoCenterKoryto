using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Windows;
using Unity;

namespace AutoCenterKorytoView
{
    public partial class WindowPurchases : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private PurchaseLogic _purchaseLogic;

        public WindowPurchases(PurchaseLogic purchaseLogic)
        {
            _purchaseLogic = purchaseLogic;
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowPurchase window = Container.Resolve<WindowPurchase>();
            window.ShowDialog();
            LoadData();
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            WindowPurchase window = Container.Resolve<WindowPurchase>();
            window.Purchase = (PurchaseViewModel)dataGridPurchases.SelectedItem;
            window.ShowDialog();
            LoadData();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridPurchases.SelectedItems.Count == 1)
                {
                    _purchaseLogic.Delete(new PurchaseBindingModel { Id = ((PurchaseViewModel)dataGridPurchases.SelectedItem).Id, ClientId = App.Client.Id });
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _purchaseLogic.Read(new PurchaseBindingModel { ClientId = App.Client.Id });
                if (list != null)
                {
                    dataGridPurchases.ItemsSource = list;
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
