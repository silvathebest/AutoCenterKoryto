using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.Interfaces
{
    public interface IClientWisheStorage
    {
        List<ClientWisheViewModel> GetFullList();
        List<ClientWisheViewModel> GetFilteredList(ClientWisheBindingModel model);
        ClientWisheViewModel GetElement(ClientWisheBindingModel model);
        void Insert(ClientWisheBindingModel model);
        void Update(ClientWisheBindingModel model);
        void Delete(ClientWisheBindingModel model);
    }
}
