using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BindingModels
{
    public class ClientWisheBindingModel
    {
        public int? Id { get; set; }
        public string Note { get; set; }
        public double TotalPrice { get; set; }
        public int PrePurchaseWorkId { get; set; }
        public int ClientId { get; set; }
    }
}
