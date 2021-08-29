using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using System;
using System.Windows;
using Unity;

namespace AutoCenterKorytoWorkerView
{
    public partial class WindowReportComplectation : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private ReportLogic _reportLogic;

        public WindowReportComplectation(ReportLogic reportLogic)
        {
            InitializeComponent();
            _reportLogic = reportLogic;
        }

        private void ButtonMake_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dataGridReport.ItemsSource = _reportLogic.ReportOnComplectationsDinamic(new ReportBindingModel
                {
                    UserId = App.Worker.Id,
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
