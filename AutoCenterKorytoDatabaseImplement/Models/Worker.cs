using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class Worker
    {
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Company { get; set; }
        [ForeignKey("WorkerId")]
        public virtual List<Car> Cars { get; set; }
        [ForeignKey("WorkerId")]
        public virtual List<Features> Features { get; set; }
        [ForeignKey("WorkerId")]
        public virtual List<Complectation> Complectations { get; set; }
    }
}
