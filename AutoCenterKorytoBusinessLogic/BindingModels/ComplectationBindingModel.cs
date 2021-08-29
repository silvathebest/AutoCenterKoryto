using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BindingModels
{
    public class ComplectationBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int WorkerId { get; set; }
        public List<int> PrePurcahseWorksIds { get; set; }
    }
}
