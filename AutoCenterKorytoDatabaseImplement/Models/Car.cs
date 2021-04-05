using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        public double Price { get; set; }
        public int YearCreation { get; set; }
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
        public int FeauturesId { get; set; }
        public virtual Features Features { get; set; }
        public int ColorId { get; set; }
        public virtual Color Color { get; set; }
        [ForeignKey("CarId")]
        public virtual List<Complectation_Car> Complectation_Cars { get; set; }
        [ForeignKey("CarId")]
        public virtual List<Purchase_Car> Purchase_Cars { get; set; }
    }
}
