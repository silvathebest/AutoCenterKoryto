using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.HelperModels
{
    public class UseOfMedicine
    {
        public string MedicineName { get; set; }
        public List<int> CountOfUse;
        public List<DateTime> Date;
    }
}
