using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using AutoCenterKorytoDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Implements
{
    public class PrePurchaseWorkStorage : IPrePurchaseWorkStorage
    {
        public void Delete(PrePurchaseWorkBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                PrePurchaseWorks work = context.PrePurchaseWorks.FirstOrDefault(rec => rec.Id == model.Id);
                if (work != null)
                {
                    context.PrePurchaseWorks.Remove(work);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Предпродажная работа не найден");
                }
            }
        }

        public PrePurchaseWorkViewModel GetElement(PrePurchaseWorkBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                PrePurchaseWorks work = context.PrePurchaseWorks
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return work != null ? CreateViewModel(work) : null;
            }
        }

        public List<PrePurchaseWorkViewModel> GetFilteredList(PrePurchaseWorkBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                return context.PrePurchaseWorks
                    .Where(rec => rec.ClientId == model.ClientId)
                    .Select(CreateViewModel).ToList();
            }
        }

        public List<PrePurchaseWorkViewModel> GetFullList()
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                return context.PrePurchaseWorks
                    .Select(CreateViewModel).ToList();
            }
        }

        public void Insert(PrePurchaseWorkBindingModel model)
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                context.PrePurchaseWorks.Add(UpdateModel(new PrePurchaseWorks(), model));
                context.SaveChanges();
            }
        }

        public void Update(PrePurchaseWorkBindingModel model)
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                var work = context.PrePurchaseWorks.FirstOrDefault(rec => rec.Id == model.Id);
                if (work == null)
                    throw new Exception($"Элемент с id {model.Id} не найден");

                UpdateModel(work, model);
                context.SaveChanges();
            }
        }

        private PrePurchaseWorkViewModel CreateViewModel(PrePurchaseWorks work)
        {
            return new PrePurchaseWorkViewModel
            {
                ClientId = work.ClientId,
                DeadlineTime = work.DeadlineDate,
                Id = work.Id,
                Name = work.Name,
                Type = work.Type
            };
        }

        private PrePurchaseWorks UpdateModel(PrePurchaseWorks work, PrePurchaseWorkBindingModel model)
        {
            work.Type = model.Type;
            work.Name = model.Name;
            work.ClientId = model.ClientId;
            work.DeadlineDate = model.DeadlineTime;
            return work;
        }
    }
}
