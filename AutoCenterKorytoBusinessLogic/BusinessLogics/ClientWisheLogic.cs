using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BusinessLogics
{
    public class ClientWisheLogic
    {
        private readonly IClientWisheStorage _ClientWisheStorage;
        public ClientWisheLogic(IClientWisheStorage clientWisheStorage)
        {
            _ClientWisheStorage = clientWisheStorage;
        }
        public List<ClientWisheViewModel> Read(ClientWisheBindingModel model)
        {
            if (model == null)
            {
                return _ClientWisheStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ClientWisheViewModel> { _ClientWisheStorage.GetElement(model) };
            }
            return _ClientWisheStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ClientWisheBindingModel model)
        {
            var ClientWishe = _ClientWisheStorage.GetElement(new ClientWisheBindingModel
            {
                Note = model.Note
            });
            if (ClientWishe != null && ClientWishe.Id != model.Id)
            {
                throw new Exception("Уже есть такое пожелание клиента");
            }
            if (model.Id.HasValue)
            {
                _ClientWisheStorage.Update(model);
            }
            else
            {
                _ClientWisheStorage.Insert(model);
            }
        }
        public void Delete(ClientWisheBindingModel model)
        {
            var ClientWishe = _ClientWisheStorage.GetElement(new ClientWisheBindingModel
            {
                Id = model.Id
            });
            if (ClientWishe == null)
            {
                throw new Exception("Пожелание не найдено");
            }
            _ClientWisheStorage.Delete(model);
        }
    }
}
