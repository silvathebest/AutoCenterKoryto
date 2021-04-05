using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BindingModels
{
    public class CarBindingModel
    {
        public int? Id { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public int YearCreation { get; set; }
        public int WorkerId { get; set; }
        public int FeaturesId { get; set; }
        public int ColorId { get; set; }
    }
}
