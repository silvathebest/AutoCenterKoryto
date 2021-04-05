using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class Color
    {
        public int Id { get; set; }
        [Required]
        public string ColorName { get; set; }
        [ForeignKey("ColorId")]
        public virtual List<Car> Car { get; set; }
    }
}
