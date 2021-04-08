using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.Interfaces
{
    public interface IComplectationStorage
    {
        List<ComplectationViewModel> GetFullList();
        List<ComplectationViewModel> GetFilteredList(ComplectationBindingModel model);
        ComplectationViewModel GetElement(ComplectationBindingModel model);
        void Insert(ComplectationBindingModel model);
        void Update(ComplectationBindingModel model);
        void Delete(ComplectationBindingModel model);
    }
}
