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
    public class WorkerStorage : IWorkerStorage
    {
        public List<WorkerViewModel> GetFullList()
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                return context.Workers
                .Select(rec => new WorkerViewModel
                {
                    Id = rec.Id,
                    FIO = rec.FIO,
                    Login = rec.Login,
                    Password = rec.Password,
                    Company = rec.Company,
                }).ToList();
            }
        }
        public List<WorkerViewModel> GetFilteredList(WorkerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AutoCenterKorytoDatabase())
            {
                return context.Workers
                .Where(rec => rec.Login.Equals(model.Login) && rec.Password.Equals(model.Password))
                .Select(rec => new WorkerViewModel
                {
                    Id = rec.Id,
                    FIO = rec.FIO,
                    Login = rec.Login,
                    Password = rec.Password,
                    Company = rec.Company,
                }).ToList();
            }
        }
        public WorkerViewModel GetElement(WorkerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AutoCenterKorytoDatabase())
            {
                var worker = context.Workers
                .FirstOrDefault(rec => rec.Id == model.Id);
                return worker != null ?
                new WorkerViewModel
                {
                    Id = worker.Id,
                    FIO = worker.FIO,
                    Login = worker.Login,
                    Password = worker.Password,
                    Company = worker.Company,
                } : null;
            }
        }
        public void Insert(WorkerBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                context.Workers.Add(CreateModel(model, new Worker()));
                context.SaveChanges();
            }
        }
        public void Update(WorkerBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                var user = context.Workers.FirstOrDefault(rec => rec.Id == model.Id);
                if (user == null)
                {
                    throw new Exception("Пользователь не найден");
                }
                CreateModel(model, user);
                context.SaveChanges();
            }
        }
        public void Delete(WorkerBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                Worker worker = context.Workers.FirstOrDefault(rec => rec.Id == model.Id);
                if (worker != null)
                {
                    context.Workers.Remove(worker);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
        }
        private Worker CreateModel(WorkerBindingModel model, Worker worker)
        {
            worker.FIO = model.FIO;
            worker.Login = model.Login;
            worker.Password = model.Password;
            worker.Company = model.Company;
            return worker;
        }
    }
}
