using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BusinessLogics
{
    public class ClientLogic
    {
        private readonly IClientStorage _ClientStorage;
        public ClientLogic(IClientStorage clientStorage)
        {
            _ClientStorage = clientStorage;
        }
        public List<ClientViewModel> Read(ClientBindingModel model)
        {
            if (model == null)
            {
                return _ClientStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ClientViewModel> { _ClientStorage.GetElement(model) };
            }
            return _ClientStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ClientBindingModel model)
        {
            var Client = _ClientStorage.GetElement(new ClientBindingModel
            {
                Login = model.Login
            });
            if (Client != null && Client.Id != model.Id)
            {
                throw new Exception("Уже есть пользователь с таким логином");
            }
            if (model.Id.HasValue)
            {
                _ClientStorage.Update(model);
            }
            else
            {
                _ClientStorage.Insert(model);
            }
        }
        public void Delete(ClientBindingModel model)
        {
            var Client = _ClientStorage.GetElement(new ClientBindingModel
            {
                Id = model.Id
            });
            if (Client == null)
            {
                throw new Exception("Пользователь не найден");
            }
            _ClientStorage.Delete(model);
        }
    }
}
