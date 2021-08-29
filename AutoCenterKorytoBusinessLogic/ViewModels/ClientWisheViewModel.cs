using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.ViewModels
{
    public class ClientWisheViewModel
    {
        public int Id { get; set; }
        [DisplayName("Примечание")]
        public string Note { get; set; }
        [DisplayName("Общая цена")]
        public double TotalPrice { get; set; }
        public int PrePurchaseWorkId { get; set; }
        public string PrePurchaseWorkName { get; set; }
        public int ClientId { get; set; }
    }
}
