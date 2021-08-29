using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class Complectation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
        [ForeignKey("ComplectationId")]
        public virtual List<Complectation_Car> Complectation_Cars { get; set; }
        [ForeignKey("ComplectationId")]
        public virtual List<PrePurchaseWorks_Complectation> PrePurchaseWorks_Complectations{ get; set; }
    }
}
