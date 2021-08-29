using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.ViewModels
{
    public class PrePurchaseWorkViewModel
    {
        public int Id { get; set; }
        [DisplayName("Тип")]
        public string Type { get; set; }
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Срок выполнения")]
        public string DeadlineTime { get; set; }
       // [DisplayName("Цена")]
       // public double Price { get; set; } // Нет в бд
        public int ClientId { get; set; }
    }
}
