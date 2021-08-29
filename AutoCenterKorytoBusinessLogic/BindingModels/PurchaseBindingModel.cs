using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BindingModels
{
    public class PurchaseBindingModel
    {
        public int? Id { get; set; }
        public DateTime DateCreate { get; set; } 
        public DateTime DateDelivery { get; set; }
        public int ClientId { get; set; }
        public double Price { get; set; }
        public Dictionary<int, string> Cars { get; set; }
        public Dictionary<int, string> PrePurchaseWorks { get; set; }
    }
}
