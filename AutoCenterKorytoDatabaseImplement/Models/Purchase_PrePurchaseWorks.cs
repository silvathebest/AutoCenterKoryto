using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class Purchase_PrePurchaseWorks
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int PrePurchaseWorksId { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual PrePurchaseWorks PrePurchaseWorks { get; set; }
    }
}
