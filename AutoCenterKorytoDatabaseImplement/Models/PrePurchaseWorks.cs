using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class PrePurchaseWorks
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Name { get; set; }
        public string DeadlineDate { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        [ForeignKey("PrePurchaseWorksId")]
        public virtual List<ClientWishes> ClientWishes { get; set; }
        [ForeignKey("PrePurchaseWorksId")]
        public virtual List<PrePurchaseWorks_Complectation> PrePurchaseWorks_Complectations { get; set; }
        [ForeignKey("PrePurchaseWorksId")]
        public virtual List<Purchase_PrePurchaseWorks> Purchase_PrePurchaseWorks { get; set; }
    }
}
