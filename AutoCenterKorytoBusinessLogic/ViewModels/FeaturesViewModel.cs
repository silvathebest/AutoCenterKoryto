using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.ViewModels
{
    public class FeaturesViewModel
    {
        public int Id { get; set; }
        [DisplayName("Описание особенности")]
        public string Description { get; set; }
        [DisplayName("Тип особенности")]
        public int Type { get; set; }
        public int WorkerId { get; set; }
        [DisplayName("ФИО Работника")]
        public string WorkerFIO { get; set; }
        public string CarName { get; set; }
        public int CarId { get; set; }
    }
}
