using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.ViewModels
{
    public class FeaturesViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название особенности")]
        public string Name { get; set; }
        [DisplayName("Тип особенности")]
        public int Type { get; set; }
        public int WorkerId { get; set; }
        [DisplayName("ФИО Работника")]
        public string WorkerFIO { get; set; }
    }
}
