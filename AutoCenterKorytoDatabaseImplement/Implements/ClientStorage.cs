using AutoCenterKorytoBusinessLogic.BindingModels;
using AutoCenterKorytoBusinessLogic.Interfaces;
using AutoCenterKorytoBusinessLogic.ViewModels;
using AutoCenterKorytoDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                return context.Clients
                .Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    FIO = rec.FIO,
                    Login = rec.Login,
                    Password = rec.Password,
                    PhoneNumber = rec.PhoneNumber,
                }).ToList();
            }
        }
        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AutoCenterKorytoDatabase())
            {
                return context.Clients
                .Where(rec => rec.Login.Equals(model.Login) && rec.Password.Equals(model.Password))
                .Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    FIO = rec.FIO,
                    Login = rec.Login,
                    Password = rec.Password,
                    PhoneNumber = rec.PhoneNumber,
                }).ToList();
            }
        }
        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AutoCenterKorytoDatabase())
            {
                var client = context.Clients
                .FirstOrDefault(rec => rec.Login == model.Login || rec.Id == model.Id);
                return client != null ?
                new ClientViewModel
                {
                    Id = client.Id,
                    FIO = client.FIO,
                    Login = client.Login,
                    Password = client.Password,
                    PhoneNumber = client.PhoneNumber,
                } : null;
            }
        }
        public void Insert(ClientBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                context.Clients.Add(CreateModel(model, new Client()));
                context.SaveChanges();
            }
        }
        public void Update(ClientBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                var user = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (user == null)
                {
                    throw new Exception("Пользователь не найден");
                }
                CreateModel(model, user);
                context.SaveChanges();
            }
        }
        public void Delete(ClientBindingModel model)
        {
            using (var context = new AutoCenterKorytoDatabase())
            {
                Client client = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (client != null)
                {
                    context.Clients.Remove(client);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Пользователь не найден");
                }
            }
        }
        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.FIO = model.FIO;
            client.Login = model.Login;
            client.Password = model.Password;
            client.PhoneNumber = model.PhoneNumber;
            return client;
        }
    }
}
