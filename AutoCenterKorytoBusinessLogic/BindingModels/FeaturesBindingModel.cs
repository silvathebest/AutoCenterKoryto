using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BindingModels
{
    public class FeaturesBindingModel
    {
        public int? Id { get; set; }
        public int Type { get; set; }
        public string Name { get; set; }
        public int WorkerId { get; set; }
    }
}
