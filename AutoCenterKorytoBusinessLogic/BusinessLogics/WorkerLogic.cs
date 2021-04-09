using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BusinessLogics
{
    public class WorkerLogic
    {
        private readonly IWorkerStorage _WorkerStorage;
        public WorkerLogic(IWorkerStorage workerStorage)
        {
            _WorkerStorage = workerStorage;
        }
        public List<WorkerViewModel> Read(WorkerBindingModel model)
        {
            if (model == null)
            {
                return _WorkerStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<WorkerViewModel> { _WorkerStorage.GetElement(model) };
            }
            return _WorkerStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(WorkerBindingModel model)
        {
            var Worker = _WorkerStorage.GetElement(new WorkerBindingModel
            {
                Login = model.Login
            });
            if (Worker != null && Worker.Id != model.Id)
            {
                throw new Exception("Уже есть пользователь с таким логином");
            }
            if (model.Id.HasValue)
            {
                _WorkerStorage.Update(model);
            }
            else
            {
                _WorkerStorage.Insert(model);
            }
        }
        public void Delete(WorkerBindingModel model)
        {
            var Client = _WorkerStorage.GetElement(new WorkerBindingModel
            {
                Id = model.Id
            });
            if (Client == null)
            {
                throw new Exception("Пользователь не найден");
            }
            _WorkerStorage.Delete(model);
        }
    }
}
