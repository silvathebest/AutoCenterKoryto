using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class Complectation_Car
    {
        public int Id { get; set; }
        public int ComplectationId { get; set; }
        public int CarId { get; set; }
        public Complectation Complectation { get; set; }
        public Car Car { get; set; }
    }
}
