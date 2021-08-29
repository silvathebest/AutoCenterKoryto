using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class Features
    {
        public int Id { get; set; }
        [Required]
        public int Type { get; set; }
        public string Description { get; set; }
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
