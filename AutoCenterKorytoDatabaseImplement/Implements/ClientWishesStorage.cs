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
    public class ClientWishesStorage : IClientWisheStorage
    {
        public void Delete(ClientWisheBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                ClientWishes wish = context.ClientWishes.FirstOrDefault(rec => rec.Id == model.Id);
                if (wish != null)
                {
                    context.ClientWishes.Remove(wish);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Пожелание не найдено");
                }
            }
        }

        public ClientWisheViewModel GetElement(ClientWisheBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                ClientWishes wish = context.ClientWishes
                    .Include(rec => rec.PrePurchaseWorks)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return wish != null ? CreateViewModel(wish) : null;
            }
        }

        public List<ClientWisheViewModel> GetFilteredList(ClientWisheBindingModel model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Null в аргументе метода");
            }
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                return context.ClientWishes
                    .Where(rec => rec.ClientId == model.ClientId)
                    .Include(rec => rec.PrePurchaseWorks)
                    .Select(CreateViewModel).ToList();
            }
        }

        public List<ClientWisheViewModel> GetFullList()
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                return context.ClientWishes
                    .Include(rec => rec.PrePurchaseWorks)
                    .Select(CreateViewModel).ToList();
            }
        }

        public void Insert(ClientWisheBindingModel model)
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                context.ClientWishes.Add(UpdateModel(new ClientWishes(), model));
                context.SaveChanges();
            }
        }

        public void Update(ClientWisheBindingModel model)
        {
            using (AutoCenterKorytoDatabase context = new AutoCenterKorytoDatabase())
            {
                var wish = context.ClientWishes.FirstOrDefault(rec => rec.Id == model.Id);
                if (wish == null)
                    throw new Exception($"Элемент с id {model.Id} не найден");

                UpdateModel(wish, model);
                context.SaveChanges();
            }
        }

        private ClientWisheViewModel CreateViewModel(ClientWishes wish)
        {
            return new ClientWisheViewModel
            {
                Id = wish.Id,
                ClientId = wish.ClientId,
                Note = wish.Name,
                TotalPrice = wish.Price,
                PrePurchaseWorkId = wish.PrePurchaseWorksId,
                PrePurchaseWorkName = wish.PrePurchaseWorks.Name
            };
        }

        private ClientWishes UpdateModel(ClientWishes wish, ClientWisheBindingModel model)
        {
            wish.Name = model.Note;
            wish.PrePurchaseWorksId = model.PrePurchaseWorkId;
            wish.Price = model.TotalPrice;
            wish.ClientId = model.ClientId;
            return wish;
        }
    }
}