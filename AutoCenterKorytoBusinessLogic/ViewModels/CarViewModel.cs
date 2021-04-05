using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.ViewModels
{
    public class CarViewModel
    {
        public int Id { get; set; }
        [DisplayName("Модель машины")]
        public string Model { get; set; }
        [DisplayName("Цена машины")]
        public double Price { get; set; }
        [DisplayName("Год выпуска")]
        public int YearCreation { get; set; }
        public int WorkerId { get; set; }
        [DisplayName("ФИО работника")]
        public string WorkerFIO { get; set; }
        public int FeatureId { get; set; }
        [DisplayName("Особенность машины")]
        public string FeatureName { get; set; }
        public int ColorId { get; set; }
        [DisplayName("Цвет")]
        public string Color { get; set; }

    }
}
