using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.ViewModels
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Дата формирования")]
        public DateTime DateCreate { get; set; }
        [DisplayName("Дата выдачи")]
        public DateTime DateDelivery { get; set; }
        //public int CarId { get; set; }
        //[DisplayName("название машины")]
        //public string CarName { get; set; }
        public Dictionary<int, string> Cars { get; set; }
        public Dictionary<int, string> PrePurchaseWorks { get; set; }

        public int ClientId { get; set; }
        [DisplayName("Цена")]
        public double Price { get; set; }
    }
}
