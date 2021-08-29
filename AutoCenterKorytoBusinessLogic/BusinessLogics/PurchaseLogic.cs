using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BusinessLogics
{
    public class PurchaseLogic
    {
        private readonly IPurchaseStorage _purchaseStorage;
        public PurchaseLogic(IPurchaseStorage purchaseStorage)
        {
            _purchaseStorage = purchaseStorage;
        }
        public List<PurchaseViewModel> Read(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return _purchaseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PurchaseViewModel> { _purchaseStorage.GetElement(model) };
            }
            return _purchaseStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(PurchaseBindingModel model)
        {
            var purchase = _purchaseStorage.GetElement(new PurchaseBindingModel
            {
                ClientId = model.ClientId,
                DateCreate = model.DateCreate,
                DateDelivery = model.DateDelivery
            }) ;//////////////////////////////////////////////////////////aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa/////////////////////////////////////////////////////////////////
            if (purchase != null && purchase.Id != model.Id)
            {
                throw new Exception("Уже есть такая покупка");
            }
            if (model.Id.HasValue)
            {
                _purchaseStorage.Update(model);
            }
            else
            {
                _purchaseStorage.Insert(model);
            }
        }
        public void Delete(PurchaseBindingModel model)
        {
            var purchase = _purchaseStorage.GetElement(new PurchaseBindingModel
            {
                Id = model.Id
            });
            if (purchase == null)
            {
                throw new Exception("Покупка не найдена");
            }
            _purchaseStorage.Delete(model);
        }
    }
}
