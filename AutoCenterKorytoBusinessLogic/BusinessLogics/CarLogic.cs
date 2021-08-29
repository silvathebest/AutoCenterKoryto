using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BusinessLogics
{
    public class CarLogic
    {
        private readonly ICarStorage _carStorage;
        public CarLogic(ICarStorage carStorage)
        {
            _carStorage = carStorage;
        }
        public List<CarViewModel> Read(CarBindingModel model)
        {
            if (model == null)
            {
                return _carStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<CarViewModel> { _carStorage.GetElement(model) };
            }
            return _carStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(CarBindingModel model)
        {
            var car = _carStorage.GetElement(new CarBindingModel { Model = model.Model });
            if (car != null && car.Id != model.Id)
            {
                throw new Exception("Уже есть такая машина");
            }
            if (model.Id.HasValue)
            {
                _carStorage.Update(model);
            }
            else
            {
                _carStorage.Insert(model);
            }
        }
        public void Delete(CarBindingModel model)
        {
            var car = _carStorage.GetElement(new CarBindingModel
            {
                Id = model.Id
            });
            if (car == null)
            {
                throw new Exception("Машина не найдена");
            }
            _carStorage.Delete(model);
        }
    }
}
