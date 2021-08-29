using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BindingModels
{
    public class PrePurchaseWorkBindingModel
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string DeadlineTime { get; set; }
        //public double Price { get; set; } // Нет в бд
        public int ClientId { get; set; }
    }
}
