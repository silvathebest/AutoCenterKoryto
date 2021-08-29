using AutoCenterKorytoBusinessLogic.BindingModels;
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
using Unity;

namespace AutoCenterKorytoView
{
    /// <summary>
    /// Логика взаимодействия для WindowClientWishes.xaml
    /// </summary>
    public partial class WindowClientWishes : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private ClientWisheLogic _clientWisheLogic;

        public WindowClientWishes(ClientWisheLogic clientWisheLogic)
        {
            _clientWisheLogic = clientWisheLogic;
            InitializeComponent();
            LoadData();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowClientWishe window = Container.Resolve<WindowClientWishe>();
            window.ShowDialog();
            LoadData();
        }

        private void ButtonUpd_Click(object sender, RoutedEventArgs e)
        {
            WindowClientWishe window = Container.Resolve<WindowClientWishe>();
            window.ClientWisheViewModel = (ClientWisheViewModel)dataGridClientWishes.SelectedItem;
            window.ShowDialog();
            LoadData();
        }

        private void ButtonDel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataGridClientWishes.SelectedItems.Count == 1)
                {
                    _clientWisheLogic.Delete(new ClientWisheBindingModel { Id = ((ClientWisheViewModel)dataGridClientWishes.SelectedItem).Id, ClientId = App.Client.Id });
                }
                MessageBox.Show("Успешно удалено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
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
                var list = _clientWisheLogic.Read(new ClientWisheBindingModel { ClientId = App.Client.Id });
                if (list != null)
                {
                    dataGridClientWishes.ItemsSource = list;
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
