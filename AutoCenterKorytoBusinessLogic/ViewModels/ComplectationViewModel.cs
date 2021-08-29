using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.ViewModels
{
    public class ComplectationViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название комплектации")]
        public string Name { get; set; }
        [DisplayName("Цена комплектации")]
        public double Price { get; set; }
        [DisplayName("Описание комплектации")]
        public string Description { get; set; }
        public int WorkerId { get; set; }
        [DisplayName("ФиО Работника")]
        public string WorkerFIO { get; set; }
        public List<int> PrePurchaseWorksIds { get; set; }

    }
}
