using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using Unity;

namespace AutoCenterKorytoWorkerView
{
    public partial class WindowListPrePuchaseWork : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private ReportLogic _reportLogic;
        private CarLogic _carLogic;

        public WindowListPrePuchaseWork(ReportLogic reportLogic, CarLogic carLogic)
        {
            InitializeComponent();
            _reportLogic = reportLogic;
            _carLogic = carLogic;
        }

        private void ButtonSaveToWord_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var carsId = new List<int>();
                        foreach (var item in dataGridCars.SelectedItems)
                        {
                            carsId.Add(((CarViewModel)item).Id);
                        }
                        _reportLogic.SavePrePurchasesWorkByCarToWordFile(new ReportBindingModel
                        {
                            UserId = App.Worker.Id,
                            FileName = dialog.FileName,
                            CarsIds = carsId
                        });
                        System.Windows.MessageBox.Show("Выполнено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                       MessageBoxImage.Error);
                    }
                }
            }
        }

        private void ButtonSaveToExcel_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var carsId = new List<int>();
                        foreach (var item in dataGridCars.SelectedItems)
                        {
                            carsId.Add(((CarViewModel)item).Id);
                        }
                        _reportLogic.SavePrePurchasesWorkByCarToExcelFile(new ReportBindingModel
                        {
                            UserId = App.Worker.Id,
                            FileName = dialog.FileName,
                            CarsIds = carsId
                        });
                        System.Windows.MessageBox.Show("Выполнено", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                       MessageBoxImage.Error);
                    }
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var list = _carLogic.Read(new CarBindingModel { WorkerId = App.Worker.Id });
                if (list != null)
                {
                    dataGridCars.ItemsSource = list;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Error);
            }
        }
    }
}
