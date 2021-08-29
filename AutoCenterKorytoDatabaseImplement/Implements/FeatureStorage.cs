using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using AutoCenterKorytoDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Implements
{
    public class FeatureStorage : IFeaturesStorage
    {
        public void Delete(FeaturesBindingModel model)
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                Features features = context.Features.FirstOrDefault(rec => rec.Id == model.Id);
                if (features != null)
                {
                    context.Features.Remove(features);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Особенность не найдена");
                }
            }
        }

        public FeaturesViewModel GetElement(FeaturesBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                Features features = context.Features
                    .Include(rec => rec.Worker)
                    .Include(rec => rec.Car)
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.Description == model.Description);
                return features != null ? CreateViewModel(features) : null;
            }
        }

        public List<FeaturesViewModel> GetFilteredList(FeaturesBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                return context.Features
                    .Include(rec => rec.Worker)
                    .Include(rec => rec.Car)
                    .Where(rec => rec.Description.Contains(model.Description)
                    || (model.WorkerId.HasValue && rec.WorkerId == model.WorkerId))
                    .Select(CreateViewModel).ToList();
            }
        }

        public List<FeaturesViewModel> GetFullList()
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                return context.Features
                    .Include(rec => rec.Worker)
                    .Include(rec => rec.Car)
                    .Select(CreateViewModel).ToList();
            }
        }

        public void Insert(FeaturesBindingModel model)
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                context.Features.Add(UpdateModel(model, new Features()));
                context.SaveChanges();
            }
        }

        public void Update(FeaturesBindingModel model)
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                Features features = context.Features.FirstOrDefault(rec => rec.Id == model.Id);
                if (features == null)
                    throw new Exception($"Элемент с id {model.Id} не найден");

                UpdateModel(model, features);
                context.SaveChanges();
            }
        }

        private FeaturesViewModel CreateViewModel(Features features)
        {
            return new FeaturesViewModel
            {
                Id = features.Id,
                Description = features.Description,
                Type = features.Type,
                CarName = features.Car.Model,
                CarId = features.CarId,
                WorkerFIO = features.Worker.FIO,
                WorkerId = features.WorkerId
            };
        }

        private Features UpdateModel(FeaturesBindingModel model, Features feature)
        {
            feature.Type = model.Type;
            feature.Description = model.Description;
            feature.WorkerId = model.WorkerId.Value;
            feature.CarId = model.CarId;
            return feature;
        }
    }
}
