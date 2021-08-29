using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using System;
using System.Windows;
using Unity;

namespace AutoCenterKorytoView
{
    public partial class WindowReport : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private ReportLogic _reportLogic;

        public WindowReport(ReportLogic reportLogic)
        {
            InitializeComponent();
            _reportLogic = reportLogic;
        }

        private void ButtonMake_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGridReport.ItemsSource = _reportLogic.ReportOnComplectationsByPeriod(new ReportBindingModel
                {
                    UserId = App.Client.Id,
                    DateFrom = DatePikerFrom.SelectedDate,
                    DateTo = DatePikerTo.SelectedDate
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonToPdf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonToMail_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
