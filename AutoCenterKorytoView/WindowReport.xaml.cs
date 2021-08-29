﻿using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogic;
using AutoCenterKorytoBusinessLogic.BusinessLogics;
using AutoCenterKorytoBusinessLogic.HelperModels;
using System;
using System.Windows;
using System.Windows.Forms;
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
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void ButtonToPdf_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        _reportLogic.SaveComplectationsByPeriodToPdfFile(new ReportBindingModel
                        {
                            FileName = dialog.FileName,
                            DateFrom = DatePikerFrom.SelectedDate.Value,
                            DateTo = DatePikerTo.SelectedDate.Value,
                            UserId = App.Client.Id
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

        private void ButtonToMail_Click(object sender, RoutedEventArgs e)
        {
            if (DatePikerFrom.SelectedDate == null || DatePikerTo.SelectedDate == null)
            {
                System.Windows.Forms.MessageBox.Show("Пожалуйста, укажите периуд", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (DatePikerFrom.SelectedDate >= DatePikerTo.SelectedDate)
            {
                System.Windows.Forms.MessageBox.Show("Начальная дата должна быть меньше конечной", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                string fileName = "__report.pdf";
                _reportLogic.SaveComplectationsByPeriodToPdfFile(new ReportBindingModel
                {
                    FileName = fileName,
                    DateFrom = DatePikerFrom.SelectedDate.Value,
                    DateTo = DatePikerTo.SelectedDate.Value,
                    UserId = App.Client.Id
                });

                MailLogic.MailSend(new MailSendInfo
                {
                    MailAddress = App.Client.Login,
                    Subject = "Отчет",
                    Text = "Отчет от " + DatePikerFrom.SelectedDate.Value.ToShortDateString() + " по " + DatePikerTo.SelectedDate.Value.ToShortDateString(),
                    FileName = fileName
                });
                System.Windows.Forms.MessageBox.Show("Выполнено", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
