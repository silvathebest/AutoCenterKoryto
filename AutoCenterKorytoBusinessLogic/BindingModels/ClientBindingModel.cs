using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.BindingModels
{
    public class ClientBindingModel
    {
        public int? Id { get; set; }
        public string FIO { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
