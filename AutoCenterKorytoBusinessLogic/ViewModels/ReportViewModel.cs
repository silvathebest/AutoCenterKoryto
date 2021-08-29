using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoBusinessLogic.ViewModels
{
    public class ReportViewModel
    {
        // Заказ
        public int Id { get; set; }       
        public DateTime DateCreate { get; set; }  
        public double TotalPrice { get; set; }
        // Комплектация
        public string ComplectationName { get; set; }
        public double ComplectationPrice { get; set; }
        public string ComplectationDescription { get; set; }
        public string WorkerFIO { get; set; }
        // Предпродажная работа
        public string PrePurchaseWorkType { get; set; }
        public string PrePurchaseWorkName { get; set; }
        public string PrePurchaseWorkDeadline { get; set; }
        // Машина
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public double CarPrice { get; set; }
        public int CarYearCreation { get; set; }
    }
}
