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
    public partial class WindowPrePurchaseWork : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public PrePurchaseWorkViewModel PreWorkViewModel { get; set; }

        private PrePurchaseWorkLogic _prePurchaseWorkLogic;

        public WindowPrePurchaseWork(PrePurchaseWorkLogic prePurchaseWorkLogic)
        {
            InitializeComponent();
            _prePurchaseWorkLogic = prePurchaseWorkLogic;

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            // Добавить проверок на пустоту полей 
            try
            {
                _prePurchaseWorkLogic.CreateOrUpdate(new PrePurchaseWorkBindingModel
                {
                    Price = Convert.ToDouble(textBoxPrice.Text),
                    Type = textBoxType.Text,
                    Name = textBoxName.Text,
                    ClientId = App.Client.Id,
                    DeadlineTime = textBoxDeadlineTime.Text,
                    Id = PreWorkViewModel?.Id
                });
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (PreWorkViewModel != null)
            {
                textBoxDeadlineTime.Text = PreWorkViewModel.DeadlineTime;
                textBoxName.Text = PreWorkViewModel.Name;
                textBoxType.Text = PreWorkViewModel.Type;
            }
        }
    }
}
