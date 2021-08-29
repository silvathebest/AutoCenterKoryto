using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BusinessLogics
{
    public class ComplectationLogic
    {
        private readonly IComplectationStorage _complectationStorage;
        public ComplectationLogic(IComplectationStorage complectationStorage)
        {
            _complectationStorage = complectationStorage;
        }
        public List<ComplectationViewModel> Read(ComplectationBindingModel model)
        {
            if (model == null)
            {
                return _complectationStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ComplectationViewModel> { _complectationStorage.GetElement(model) };
            }
            return _complectationStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(ComplectationBindingModel model)
        {
            var complectation = _complectationStorage.GetElement(new ComplectationBindingModel { Name = model.Name });
            if (complectation != null && complectation.Id != model.Id)
            {
                throw new Exception("Уже есть такая комплектация");
            }
            if (model.Id.HasValue)
            {
                _complectationStorage.Update(model);
            }
            else
            {
                _complectationStorage.Insert(model);
            }
        }
        public void Delete(ComplectationBindingModel model)
        {
            var complectation = _complectationStorage.GetElement(new ComplectationBindingModel
            {
                Id = model.Id
            });
            if (complectation == null)
            {
                throw new Exception("Комплектация не найдена");
            }
            _complectationStorage.Delete(model);
        }
    }
}
