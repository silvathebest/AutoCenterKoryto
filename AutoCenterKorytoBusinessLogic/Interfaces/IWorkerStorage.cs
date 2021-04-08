using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.Interfaces
{
    public interface IWorkerStorage
    {
        List<WorkerViewModel> GetFullList();
        List<WorkerViewModel> GetFilteredList(WorkerBindingModel model);
        WorkerViewModel GetElement(WorkerBindingModel model);
        void Insert(WorkerBindingModel model);
        void Update(WorkerBindingModel model);
        void Delete(WorkerBindingModel model);
    }
}
