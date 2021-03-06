﻿using System;
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
        public Dictionary<int, string> PurchaseCars { get; set; }
        public Dictionary<int, string> Purchase_PrePurchaseWorks { get; set; }
    }
}
