using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using AutoCenterKorytoDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Implements
{
    public class ComplectationStorage : IComplectationStorage
    {
        public void Delete(ComplectationBindingModel model)
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                Complectation complectation = context.Complectations.FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
                if (complectation != null)
                {
                    context.Complectations.Remove(complectation);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Комплектация не найдена");
                }
            }
        }

        public ComplectationViewModel GetElement(ComplectationBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                Complectation сomplectation = context.Complectations
                    .Include(rec => rec.Worker)
                    .Include(rec => rec.PrePurchaseWorks_Complectations)
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
                return сomplectation != null ? CreateViewModel(сomplectation) : null;
            }
        }

        public List<ComplectationViewModel> GetFilteredList(ComplectationBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                return context.Complectations
                    .Where(rec => rec.WorkerId == model.WorkerId)
                    .Include(rec => rec.Worker)
                    .Include(rec => rec.PrePurchaseWorks_Complectations)
                    .Select(CreateViewModel).ToList();
            }
        }

        public List<ComplectationViewModel> GetFullList()
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                return context.Complectations
                    .Include(rec => rec.Worker)
                    .Include(rec => rec.PrePurchaseWorks_Complectations)
                    .Select(CreateViewModel).ToList();
            }
        }

        public void Insert(ComplectationBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                context.Complectations.Add(UpdateModel(new Complectation(), model));
                context.SaveChanges();
            }
        }

        public void Update(ComplectationBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }

            using (var context = new AutoCenterKorytoDatabase())
            {
                var complectation = context.Complectations.FirstOrDefault(rec => rec.Id == model.Id);
                if(complectation == null)
                    throw new Exception($"Элемент с id {model.Id} не найден");

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        UpdateModel(complectation, model);

                        var complectationPreWork = context.PrePurchaseWorks_Complectations.Where(pc => pc.ComplectationId == complectation.Id).ToList();

                        context.PrePurchaseWorks_Complectations.RemoveRange(complectationPreWork.Where(cp => !model.PrePurcahseWorksIds.Contains(cp.PrePurchaseWorksId)));

                        foreach (var cp in complectationPreWork)
                        {
                            model.PrePurcahseWorksIds.Remove(cp.PrePurchaseWorksId);
                        }

                        context.SaveChanges();

                        foreach (var preWorkId in model.PrePurcahseWorksIds)
                        {
                            context.PrePurchaseWorks_Complectations.Add(new PrePurchaseWorks_Complectation
                            {
                                ComplectationId = complectation.Id,
                                PrePurchaseWorksId = preWorkId
                            });
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private ComplectationViewModel CreateViewModel(Complectation сomplectation)
        {
            return new ComplectationViewModel
            {
                Id = сomplectation.Id,
                Description = сomplectation.Description,
                Price = сomplectation.Price,
                Name = сomplectation.Name,
                WorkerFIO = сomplectation.Worker.FIO,
                WorkerId = сomplectation.WorkerId,
                PrePurchaseWorksIds = сomplectation.PrePurchaseWorks_Complectations.Select(pc => pc.PrePurchaseWorksId).ToList(),
            };
        }

        private Complectation UpdateModel(Complectation oldComplectation, ComplectationBindingModel model)
        {
            oldComplectation.Name = model.Name;
            oldComplectation.Price = model.Price;
            oldComplectation.WorkerId = model.WorkerId;
            oldComplectation.Description = model.Description;
            return oldComplectation;
        }
    }
}
