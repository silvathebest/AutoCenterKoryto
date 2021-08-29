using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.BusinessLogic;
using AutoCenterKorytoBusinessLogic.HelperModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IReportDataProvider _reportDataProvider;

        public ReportLogic(IReportDataProvider reportDataProvider)
        {
            _reportDataProvider = reportDataProvider;
        }

        // Проброс методов интерфейса
        public List<ReportViewModel> ReportOnComplectationsByPurchases(ReportBindingModel model)
        {
            return _reportDataProvider.ReportOnComplectationsByPurchases(model);
        }

        public List<ReportViewModel> ReportOnComplectationsByPeriod(ReportBindingModel model)
        {
            return _reportDataProvider.ReportOnComplectationsByPeriod(model);
        }

        public List<ReportViewModel> ReportOnPrePurchasesWorkByCar(ReportBindingModel model)
        {
            return _reportDataProvider.ReportOnPrePurchasesWorkByCar(model);
        }

        public List<ReportViewModel> ReportOnComplectationsDinamic(ReportBindingModel model)
        {
            return _reportDataProvider.ReportOnComplectationsDinamic(model);

        }
        ////

        // Для клиента
        public void SaveComplectationsByPurchasesToWordFile(ReportBindingModel binding)
        {
            SaveToWord.ComplectationsByPurchases(new WordInfo
            {
                FileName = binding.FileName,
                Title = "Комплектации из заказов",
                DataForReport = ReportOnComplectationsByPurchases(binding)
            });
        }

        public void SaveComplectationsByPurchasesToExcelFile(ReportBindingModel binding)
        {
            SaveToExcel.ComplectationsByPurchases(new ExcelInfo
            {
                FileName = binding.FileName,
                Title = "Комплектации из заказов",
                DataForReport = ReportOnComplectationsByPurchases(binding)
            });
        }

        public void SaveComplectationsByPeriodToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.ComplectationsByPeriod(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Отчет по покупаемым комплектациям за пириуд",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                DataForReport = ReportOnComplectationsByPeriod(model)
            });
        }

        // Для работника
        public void SavePrePurchasesWorkByCarToWordFile(ReportBindingModel binding)
        {
            SaveToWord.PrePurchasesWorkByCar(new WordInfo
            {
                FileName = binding.FileName,
                Title = "Предпродажные работы для машин",
                DataForReport = ReportOnPrePurchasesWorkByCar(binding)
            });
        }

        public void SavePrePurchasesWorkByCarToExcelFile(ReportBindingModel binding)
        {
            SaveToExcel.PrePurchasesWorkByCar(new ExcelInfo
            {
                FileName = binding.FileName,
                Title = "Предпродажные работы для машин",
                DataForReport = ReportOnPrePurchasesWorkByCar(binding)
            });
        }

        public void SaveComplectationsDinamicToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.ComplectationsDinamic(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Отчет по движению комплектаций за периуд",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                DataForReport = ReportOnComplectationsDinamic(model)
            });
        }
    }
}
