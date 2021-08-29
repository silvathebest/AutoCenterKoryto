using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace AutoCenterKorytoBusinessLogic.Interfaces
{
    public interface IPrePurchaseWorkStorage
    {
        List<PrePurchaseWorkViewModel> GetFullList();
        List<PrePurchaseWorkViewModel> GetFilteredList(PrePurchaseWorkBindingModel model);
        PrePurchaseWorkViewModel GetElement(PrePurchaseWorkBindingModel model);
        void Insert(PrePurchaseWorkBindingModel model);
        void Update(PrePurchaseWorkBindingModel model);
        void Delete(PrePurchaseWorkBindingModel model);
    }
}
