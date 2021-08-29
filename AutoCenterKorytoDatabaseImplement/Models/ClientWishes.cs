    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class ClientWishes
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int PrePurchaseWorksId { get; set; }
        public virtual PrePurchaseWorks PrePurchaseWorks { get; set; }
    }
}
