using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime DateDelivery { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        [ForeignKey("PurchaseId")]
        public virtual List<Purchase_Car> Purchase_Cars { get; set; }
        [ForeignKey("PurchaseId")]
        public virtual List<Purchase_PrePurchaseWorks> Purchase_PrePurchaseWorks { get; set; }
    }
}
