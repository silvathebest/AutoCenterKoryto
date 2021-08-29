using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;
using Unity;

namespace AutoCenterKorytoView
{
    public partial class WindowComplectationList : Window
    {
        private PurchaseLogic _purchaseLogic;
        private ReportLogic _reportLogic;
        public WindowComplectationList(PurchaseLogic purchaseLogic, ReportLogic reportLogic)
        {
            InitializeComponent();
            _purchaseLogic = purchaseLogic;
            _reportLogic = reportLogic;
        }

        private void bWord_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var purchasesId = new List<int>();
                        foreach (var item in dataGridPurchapses.SelectedItems)
                        {
                            purchasesId.Add(((PurchaseViewModel)item).Id);
                        }
                        _reportLogic.SaveComplectationsByPurchasesToWordFile(new ReportBindingModel
                        {
                            UserId = App.Client.Id,
                            FileName = dialog.FileName,
                            PurchasesIds = purchasesId
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

        private void bExcel_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var purchasesId = new List<int>();
                        foreach (var item in dataGridPurchapses.SelectedItems)
                        {
                            purchasesId.Add(((PurchaseViewModel)item).Id);
                        }
                        _reportLogic.SaveComplectationsByPurchasesToExcelFile(new ReportBindingModel
                        {
                            UserId = App.Client.Id,
                            FileName = dialog.FileName,
                            PurchasesIds = purchasesId
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
                var list = _purchaseLogic.Read(new PurchaseBindingModel { ClientId = App.Client.Id });
                if (list != null)
                {
                    dataGridPurchapses.ItemsSource = list;
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
