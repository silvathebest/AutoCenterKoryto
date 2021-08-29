using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using AutoCenterKorytoDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoCenterKorytoDatabaseImplement.Implements
{
    public class CarStorage : ICarStorage
    {
        public void Delete(CarBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                Car car = context.Cars.FirstOrDefault(rec => rec.Id == model.Id);
                if (car != null)
                {
                    context.Cars.Remove(car);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Автомобиль не найден");
                }
            }
        }

        public CarViewModel GetElement(CarBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }
            using (var context = new AutoCenterKorytoDatabase())
            {
                var car = context.Cars
                    .Where(rec => rec.Id == model.Id)
                    .Include(rec => rec.Worker)
                    .Include(rec => rec.Complectation_Cars).ThenInclude(cc => cc.Complectation)
                    .FirstOrDefault();
                return car != null ? CreateViewModel(car) : null;
            }
        }

        public List<CarViewModel> GetFilteredList(CarBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }
            using (var context = new AutoCenterKorytoDatabase())
            {
                return context.Cars
                    .Where(rec => rec.WorkerId == model.WorkerId)
                    .Include(rec => rec.Worker)
                    .Include(rec => rec.Complectation_Cars).ThenInclude(cc => cc.Complectation)
                    .Select(CreateViewModel).ToList();
            }
        }

        public List<CarViewModel> GetFullList()
        {
           
            using (var context = new AutoCenterKorytoDatabase())
            {
                return context.Cars
                    .Include(rec => rec.Worker)
                     .Include(rec => rec.Complectation_Cars).ThenInclude(cc => cc.Complectation)
                    .Select(CreateViewModel).ToList();
            }
        }

        public void Insert(CarBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }

            using (var context = new AutoCenterKorytoDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var car = new Car();
                        context.Cars.Add(UpdateModel(car, model));
                        context.SaveChanges();
                        foreach (var complectationId in model.ComplectationsIds)
                        {
                            context.Complectation_Cars.Add(new Complectation_Car
                            {
                                CarId = car.Id,
                                ComplectationId = complectationId
                            });
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(CarBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }

            using (var context = new AutoCenterKorytoDatabase())
            {
                var car = context.Cars.FirstOrDefault(c => c.Id == model.Id);
                if (car == null)
                    throw new Exception($"Элемент с id {model.Id} не найден");

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        UpdateModel(car, model);
                        
                        var carComplectations = context.Complectation_Cars.Where(cc => cc.CarId == car.Id).ToList();

                        context.Complectation_Cars.RemoveRange(carComplectations.Where(cc => !model.ComplectationsIds.Contains(cc.ComplectationId)));

                        foreach (var cc in carComplectations)
                        {
                            model.ComplectationsIds.Remove(cc.ComplectationId);
                        }

                        context.SaveChanges();

                        foreach (var complectationId in model.ComplectationsIds)
                        {
                            context.Complectation_Cars.Add(new Complectation_Car
                            {
                                CarId = car.Id,
                                ComplectationId = complectationId
                            });
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        private CarViewModel CreateViewModel(Car car)
        {
            return new CarViewModel
            {
                Id = car.Id,
                Model = car.Model,
                ColorName = car.ColorName,
                Price = car.Price,
                WorkerFIO = car.Worker.FIO,
                WorkerId = car.WorkerId,
                YearCreation = car.YearCreation,
                Complectations = car.Complectation_Cars.ToDictionary(cc => cc.ComplectationId, cc => (cc.Complectation.Name, cc.Complectation.Price))
            };
        }

        private Car UpdateModel(Car oldCar, CarBindingModel model)
        {
            oldCar.Model = model.Model;
            oldCar.Price = model.Price;
            oldCar.WorkerId = model.WorkerId;
            oldCar.ColorName = model.ColorName;
            oldCar.YearCreation = model.YearCreation;
            
            return oldCar;
        }
    }
}
