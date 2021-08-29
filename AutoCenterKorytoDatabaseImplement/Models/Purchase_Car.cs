using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class Purchase_Car
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int CarId { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual Car Car { get; set; }
    }
}
