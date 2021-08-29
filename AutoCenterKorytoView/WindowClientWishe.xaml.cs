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
    public partial class WindowClientWishe : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public ClientWisheViewModel ClientWisheViewModel { get; set; }

        private ClientWisheLogic _clientWisheLogic;
        private PrePurchaseWorkLogic _prePurchaseWorkLogic;

        public WindowClientWishe(ClientWisheLogic clientWisheLogic, PrePurchaseWorkLogic prePurchaseWorkLogic)
        {
            _clientWisheLogic = clientWisheLogic;
            _prePurchaseWorkLogic = prePurchaseWorkLogic;
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            // Добавить проверок на пустоту полей 
            try
            {
                _clientWisheLogic.CreateOrUpdate(new ClientWisheBindingModel
                {

                    Note = textBoxNote.Text,
                    ClientId = App.Client.Id,
                    Id = ClientWisheViewModel?.Id,
                    PrePurchaseWorkId = ((PrePurchaseWorkViewModel)comboBoxPrePurchaseWorks.SelectedItem).Id
                });
                MessageBox.Show("Добавлено");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var list = _prePurchaseWorkLogic.Read(null);
            if(list != null && list.Count > 0)
            {
                comboBoxPrePurchaseWorks.ItemsSource = list;
                comboBoxPrePurchaseWorks.SelectedItem = list[0];
            }

            if (ClientWisheViewModel != null)
            {
                textBoxNote.Text = ClientWisheViewModel.Note;
                comboBoxPrePurchaseWorks.SelectedItem = list?.FirstOrDefault(pp => pp.Id == ClientWisheViewModel.PrePurchaseWorkId);
            }
        }
    }
}
