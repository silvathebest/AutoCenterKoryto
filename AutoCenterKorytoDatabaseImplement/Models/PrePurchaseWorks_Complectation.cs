using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class PrePurchaseWorks_Complectation
    {
        public int Id { get; set; }
        public int PrePurchaseWorksId { get; set; }
        public int ComplectationId { get; set; }
        public virtual PrePurchaseWorks PrePurchaseWorks { get; set; }
        public virtual Complectation Complectation { get; set; }
    }
}
