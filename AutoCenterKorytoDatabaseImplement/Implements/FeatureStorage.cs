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
                return null;
            }
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                Features features = context.Features
                    .Include(rec => rec.Worker)
                    .FirstOrDefault(rec => rec.Id == model.Id || rec.Description == model.Description);
                return features != null ?
                new FeaturesViewModel
                {
                    Id = features.Id,
                    Description = features.Description,
                    Type = features.Type,
                    WorkerFIO = features.Worker.FIO,
                    WorkerId = features.WorkerId
                } : null;
            }
        }

        public List<FeaturesViewModel> GetFilteredList(FeaturesBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                return context.Features
                    .Include(rec => rec.Worker)
                    .Where(rec => rec.Description.Contains(model.Description)
                    || (model.WorkerId.HasValue && rec.WorkerId == model.WorkerId))
                    .Select(rec => new FeaturesViewModel
                    {
                        Id = rec.Id,
                        Description = rec.Description,
                        Type = rec.Type,
                        WorkerFIO = rec.Worker.FIO,
                        WorkerId = rec.WorkerId
                    }).ToList();
            }
        }

        public List<FeaturesViewModel> GetFullList()
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                return context.Features
                    .Include(rec => rec.Worker)
                    .Select(rec => new FeaturesViewModel
                    {
                        Id = rec.Id,
                        Description = rec.Description,
                        Type = rec.Type,
                        WorkerFIO = rec.Worker.FIO,
                        WorkerId = rec.WorkerId
                    }).ToList();
            }
        }

        public void Insert(FeaturesBindingModel model)
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                context.Features.Add(CreateModel(model, new Features()));
                context.SaveChanges();
            }
        }

        public void Update(FeaturesBindingModel model)
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                Features features = context.Features.FirstOrDefault(rec => rec.Id == model.Id);
                if (features == null)
                {
                    throw new Exception("Особенность не найдена");
                }
                CreateModel(model, features);
                context.SaveChanges();
            }
        }

        public Features CreateModel(FeaturesBindingModel model, Features feature)
        {
            feature.Type = model.Type;
            feature.Description = model.Description;
            feature.WorkerId = (int)model.WorkerId;
            return feature;
        }
    }
}
