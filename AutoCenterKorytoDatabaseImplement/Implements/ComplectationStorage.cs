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
                return null;
            }
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                Complectation сomplectation = context.Complectations
                    .Include(rec => rec.Worker)
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.Name == model.Name);
                return сomplectation != null ?
                new ComplectationViewModel
                {
                    Id = сomplectation.Id,
                    Description = сomplectation.Description,
                    Price = сomplectation.Price,
                    Name = сomplectation.Name,
                    WorkerFIO = сomplectation.Worker.FIO,
                    WorkerId = сomplectation.WorkerId,
                } : null;
            }
        }

        public List<ComplectationViewModel> GetFilteredList(ComplectationBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<ComplectationViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public void Insert(ComplectationBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(ComplectationBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
