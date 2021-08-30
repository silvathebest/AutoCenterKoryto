using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Windows;


namespace AutoCenterKorytoWorkerView
{
    public partial class WindowComplectation : Window
    {
        private ComplectationLogic _complectationLogic;
        public ComplectationViewModel Complectation { get; set; }

        public WindowComplectation(ComplectationLogic complectationLogic)
        {
            _complectationLogic = complectationLogic;
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _complectationLogic.CreateOrUpdate(new ComplectationBindingModel
                {
                    Description = textBoxDescription.Text,
                    Name = textBoxName.Text,
                    Price = Convert.ToDouble(textBoxPrice.Text),
                    WorkerId = App.Worker.Id,
                    Id = Complectation?.Id,
                    PrePurcahseWorksIds = Complectation.PrePurchaseWorksIds
                });
                MessageBox.Show("Успех");
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
            if (Complectation != null)
            {
                textBoxDescription.Text = Complectation.Description;
                textBoxName.Text = Complectation.Name;
                textBoxPrice.Text = Complectation.Price.ToString();
            }
        }
    }
}
