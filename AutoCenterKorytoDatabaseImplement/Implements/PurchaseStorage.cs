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
    public class PurchaseStorage : IPurchaseStorage
    {
        public void Delete(PurchaseBindingModel model)
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                var purchase = context.Purchases.FirstOrDefault(rec => rec.Id == model.Id);
                if (purchase != null)
                {
                    context.Purchases.Remove(purchase);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Заказ не найден");
                }
            }
        }

        public PurchaseViewModel GetElement(PurchaseBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }
            using (var context = new AutoCenterKorytoDatabase())
            {
                var purchase = context.Purchases
                    .Where(rec => rec.Id == model.Id)
                    .Include(rec => rec.Purchase_Cars).ThenInclude(pc => pc.Car)
                    .Include(rec => rec.Purchase_PrePurchaseWorks).ThenInclude(pp => pp.PrePurchaseWorks)
                    .FirstOrDefault();
                return purchase != null ? CreateViewModel(purchase) : null;
            }
        }

        public List<PurchaseViewModel> GetFilteredList(PurchaseBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }
            using (var context = new AutoCenterKorytoDatabase())
            {
                return context.Purchases
                    .Where(rec => rec.ClientId == model.ClientId)
                    .Include(rec => rec.Purchase_Cars).ThenInclude(pc => pc.Car)
                    .Include(rec => rec.Purchase_PrePurchaseWorks).ThenInclude(pp => pp.PrePurchaseWorks)
                    .Select(CreateViewModel).ToList();
            }
        }

        public List<PurchaseViewModel> GetFullList()
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                return context.Purchases
                    .Include(rec => rec.Purchase_Cars).ThenInclude(pc => pc.Car)
                    .Include(rec => rec.Purchase_PrePurchaseWorks).ThenInclude(pp => pp.PrePurchaseWorks)
                    .Select(CreateViewModel).ToList();
            }
        }

        public void Insert(PurchaseBindingModel model)
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
                        var purchase = new Purchase();
                        context.Purchases.Add(UpdateModel(purchase, model));
                        context.SaveChanges();
                        foreach (var carId in model.Cars.Keys)
                        {
                            context.Purchase_Cars.Add(new Purchase_Car
                            {
                                CarId = carId,
                                PurchaseId = purchase.Id
                            });
                        }
                        foreach (var preWorkId in model.PrePurchaseWorks.Keys)
                        {
                            context.Purchase_PrePurchaseWorks.Add(new Purchase_PrePurchaseWorks
                            {
                                PurchaseId = purchase.Id,
                                PrePurchaseWorksId = preWorkId
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

        public void Update(PurchaseBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }

            using (var context = new AutoCenterKorytoDatabase())
            {
                var purchase = context.Purchases.FirstOrDefault(p => p.Id == model.Id);
                if (purchase == null)
                    throw new Exception($"Элемент с id {model.Id} не найден");

                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        UpdateModel(purchase, model);

                        var purchase_preWorks = context.Purchase_PrePurchaseWorks.Where(pp => pp.PurchaseId == model.Id).ToList();

                        context.Purchase_PrePurchaseWorks.RemoveRange(purchase_preWorks.Where(pp => !model.PrePurchaseWorks.ContainsKey(pp.PrePurchaseWorksId)));

                        foreach (var pp in purchase_preWorks)
                        {
                            model.PrePurchaseWorks.Remove(pp.PrePurchaseWorksId);
                        }

                        var purchase_cars = context.Purchase_Cars.Where(pc => pc.PurchaseId == model.Id).ToList();

                        context.Purchase_Cars.RemoveRange(purchase_cars.Where(pc => !model.Cars.ContainsKey(pc.CarId)));

                        foreach (var pc in purchase_cars)
                        {
                            model.Cars.Remove(pc.CarId);
                        }

                        foreach (var carId in model.Cars.Keys)
                        {
                            context.Purchase_Cars.Add(new Purchase_Car
                            {
                                CarId = carId,
                                PurchaseId = purchase.Id
                            });
                        }
                        foreach (var preWorkId in model.PrePurchaseWorks.Keys)
                        {
                            context.Purchase_PrePurchaseWorks.Add(new Purchase_PrePurchaseWorks
                            {
                                PurchaseId = purchase.Id,
                                PrePurchaseWorksId = preWorkId
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

        private PurchaseViewModel CreateViewModel(Purchase purchase)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                var cars = context.Cars;
                var selectedCarsId = purchase.Purchase_Cars.Where(pc => pc.PurchaseId == purchase.Id).Select(pc => pc.CarId);
                var sum = cars.Where(c => selectedCarsId.Contains(c.Id)).Sum(c => c.Price);
                return new PurchaseViewModel
                {
                    ClientId = purchase.ClientId,
                    DateCreate = purchase.DateCreate,
                    DateDelivery = purchase.DateDelivery,
                    Id = purchase.Id,
                    Price = sum,
                    PrePurchaseWorks = purchase.Purchase_PrePurchaseWorks.ToDictionary(pp => pp.PrePurchaseWorksId, pp => pp.PrePurchaseWorks.Name),
                    Cars = purchase.Purchase_Cars.ToDictionary(pc => pc.CarId, pc => pc.Car.Model),
                };
            }
        }

        private Purchase UpdateModel(Purchase purchase, PurchaseBindingModel model)
        {
            purchase.ClientId = model.ClientId;
            purchase.DateCreate = model.DateCreate;
            purchase.DateDelivery = model.DateDelivery;
            return purchase;
        }
    }
}
