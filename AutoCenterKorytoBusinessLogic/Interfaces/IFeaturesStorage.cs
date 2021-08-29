using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.Interfaces
{
    public interface IFeaturesStorage
    {
        List<FeaturesViewModel> GetFullList();
        List<FeaturesViewModel> GetFilteredList(FeaturesBindingModel model);
        FeaturesViewModel GetElement(FeaturesBindingModel model);
        void Insert(FeaturesBindingModel model);
        void Update(FeaturesBindingModel model);
        void Delete(FeaturesBindingModel model);
    }
}
