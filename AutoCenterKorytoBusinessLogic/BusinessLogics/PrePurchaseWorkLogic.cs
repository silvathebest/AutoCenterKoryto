using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BusinessLogics
{
    public class PrePurchaseWorkLogic
    {
        private readonly IPrePurchaseWorkStorage _prePurchaseWorkStorage;
        public PrePurchaseWorkLogic(IPrePurchaseWorkStorage prePurchaseWorkStorage)
        {
            _prePurchaseWorkStorage = prePurchaseWorkStorage;
        }
        public List<PrePurchaseWorkViewModel> Read(PrePurchaseWorkBindingModel model)
        {
            if (model == null)
            {
                return _prePurchaseWorkStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PrePurchaseWorkViewModel> { _prePurchaseWorkStorage.GetElement(model) };
            }
            return _prePurchaseWorkStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(PrePurchaseWorkBindingModel model)
        {
            var prePurchaseWork = _prePurchaseWorkStorage.GetElement(new PrePurchaseWorkBindingModel
            {
                Name = model.Name
            });
            if (prePurchaseWork != null && prePurchaseWork.Id != model.Id)
            {
                throw new Exception("Уже есть такая предпродажная работа");
            }
            if (model.Id.HasValue)
            {
                _prePurchaseWorkStorage.Update(model);
            }
            else
            {
                _prePurchaseWorkStorage.Insert(model);
            }
        }
        public void Delete(PrePurchaseWorkBindingModel model)
        {
            var prePurchaseWork = _prePurchaseWorkStorage.GetElement(new PrePurchaseWorkBindingModel
            {
                Name = model.Name
            });
            if (prePurchaseWork == null)
            {
                throw new Exception("Предпродажная работа не найдена");
            }
            _prePurchaseWorkStorage.Delete(model);
        }
    }
}
