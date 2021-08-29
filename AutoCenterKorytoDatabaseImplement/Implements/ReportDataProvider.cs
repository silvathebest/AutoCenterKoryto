using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Implements
{
    public class ReportDataProvider : IReportDataProvider
    {
        public List<ReportViewModel> ReportOnComplectationsByPeriod(ReportBindingModel model)
        {
            if (model.DateFrom.HasValue == false || model.DateTo.HasValue == false || model.DateTo < model.DateFrom)
                throw new Exception("Периуд для формирования отчета не указан или указан неверно");

            using(var context = new AutoCenterKorytoDatabase())
            {
                var res = from purchase in context.Purchases.Where(p => p.ClientId == model.UserId && p.DateCreate >= model.DateFrom && p.DateCreate <= model.DateTo )
                          join purchase_preWork in context.Purchase_PrePurchaseWorks
                          on purchase.Id equals purchase_preWork.PurchaseId
                          join preWork in context.PrePurchaseWorks
                          on purchase_preWork.PrePurchaseWorksId equals preWork.Id
                          join preWork_complectation in context.PrePurchaseWorks_Complectations
                          on preWork.Id equals preWork_complectation.PrePurchaseWorksId
                          join complectation in context.Complectations
                          on preWork_complectation.ComplectationId equals complectation.Id
                          select new ReportViewModel
                          {
                              Id = purchase.Id,
                              DateCreate = purchase.DateCreate,

                              ComplectationName = complectation.Name,
                              ComplectationDescription = complectation.Description,
                              ComplectationPrice = complectation.Price,
                            
                              PrePurchaseWorkName = preWork.Name,
                              PrePurchaseWorkType = preWork.Type,
                              PrePurchaseWorkDeadline = preWork.DeadlineDate
                          };
                          
                return res.ToList();      
            }
        }

        public List<ReportViewModel> ReportOnComplectationsByPurchases(ReportBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                var res = from purchase in context.Purchases.Where(p => p.ClientId == model.UserId && model.PurchasesIds.Contains(p.Id))
                          join purchase_car in context.Purchase_Cars
                          on purchase.Id equals purchase_car.PurchaseId
                          join car in context.Cars
                          on purchase_car.CarId equals car.Id
                          join complectation_car in context.Complectation_Cars
                          on car.Id equals complectation_car.CarId
                          join complectation in context.Complectations
                          on complectation_car.ComplectationId equals complectation.Id
                          select new ReportViewModel
                          {
                              DateCreate = purchase.DateCreate,
                              Id = purchase.Id,

                              ComplectationName = complectation.Name,
                              ComplectationDescription = complectation.Description,
                              ComplectationPrice = complectation.Price,

                              CarModel = car.Model,
                              CarPrice = car.Price,
                              CarYearCreation = car.YearCreation
                          };
                return res.ToList();
            }
        }

        public List<ReportViewModel> ReportOnComplectationsDinamic(ReportBindingModel model)
        {
            if (model.DateFrom.HasValue == false || model.DateTo.HasValue == false || model.DateTo < model.DateFrom)
                throw new Exception("Периуд для формирования отчета не указан или указан неверно");

            using (var context = new AutoCenterKorytoDatabase())
            {
                var res = from purchase in context.Purchases.Where(p => p.DateCreate >= model.DateFrom && p.DateCreate <= model.DateTo)
                          join purchase_preWork in context.Purchase_PrePurchaseWorks
                          on purchase.Id equals purchase_preWork.PurchaseId
                          join preWork in context.PrePurchaseWorks
                          on purchase_preWork.PrePurchaseWorksId equals preWork.Id
                          join preWork_complectation in context.PrePurchaseWorks_Complectations
                          on preWork.Id equals preWork_complectation.PrePurchaseWorksId
                          join complectation in context.Complectations.Where(c => c.WorkerId == model.UserId)
                          on preWork_complectation.ComplectationId equals complectation.Id
                          select new ReportViewModel
                          {
                              DateCreate = purchase.DateCreate,
                              ComplectationName = complectation.Name,
                              ComplectationDescription = complectation.Description,
                              ComplectationPrice = complectation.Price,
                              PrePurchaseWorkName = preWork.Name,
                              PrePurchaseWorkDeadline = preWork.DeadlineDate
                          };

                return res.ToList();
            }
        }

        public List<ReportViewModel> ReportOnPrePurchasesWorkByCar(ReportBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                var res = from car in context.Cars.Where(c => c.WorkerId == model.UserId && model.CarsIds.Contains(c.Id))
                          join purchase_car in context.Purchase_Cars
                          on car.Id equals purchase_car.CarId
                          join purchase in context.Purchases
                          on purchase_car.PurchaseId equals purchase.Id
                          join purchase_preWork in context.Purchase_PrePurchaseWorks
                          on purchase.Id equals purchase_preWork.PurchaseId
                          join preWork in context.PrePurchaseWorks
                          on purchase_preWork.PrePurchaseWorksId equals preWork.Id
                          select new ReportViewModel
                          {
                              CarId = car.Id,
                              CarModel = car.Model,
                              CarYearCreation = car.YearCreation,
                              CarPrice = car.Price,
                              PrePurchaseWorkName = preWork.Name,
                              PrePurchaseWorkType = preWork.Type,
                              PrePurchaseWorkDeadline = preWork.DeadlineDate,
                              Id = purchase.Id
                          };

                return res.ToList();
            }
        }
    }
}
