using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BusinessLogics
{
    public class FeaturesLogic
    {
        private readonly IFeaturesStorage _featuresStorage;
        public FeaturesLogic(IFeaturesStorage featuresStorage)
        {
            _featuresStorage = featuresStorage;
        }

        public List<FeaturesViewModel> Read(FeaturesBindingModel model)
        {
            if (model == null)
            {
                return _featuresStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<FeaturesViewModel> { _featuresStorage.GetElement(model) };
            }
            return _featuresStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(FeaturesBindingModel model)
        {
            var feature = _featuresStorage.GetElement(new FeaturesBindingModel { Description = model.Description });
            if (feature != null && feature.Id != model.Id)
            {
                throw new Exception("Уже есть такая особенность");
            }
            if (model.Id.HasValue)
            {
                _featuresStorage.Update(model);
            }
            else
            {
                _featuresStorage.Insert(model);
            }
        }
        public void Delete(FeaturesBindingModel model)
        {
            var feature = _featuresStorage.GetElement(new FeaturesBindingModel
            {
                Id = model.Id
            });
            if (feature == null)
            {
                throw new Exception("Особенность не найдена");
            }
            _featuresStorage.Delete(model);
        }
    }
}
