using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.Interfaces
{
    public interface IReportDataProvider
    {
        List<ReportViewModel> ReportOnComplectationsByPurchases(ReportBindingModel model);
        List<ReportViewModel> ReportOnComplectationsByPeriod(ReportBindingModel model);

        List<ReportViewModel> ReportOnPrePurchasesWorkByCar(ReportBindingModel model);
        List<ReportViewModel> ReportOnComplectationsDinamic(ReportBindingModel model);
    }
}
