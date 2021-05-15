using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoCenterKorytoDatabaseImplement.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string FIO { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [ForeignKey("ClientId")]
        public virtual List<Purchase> Purchases { get; set; }
        [ForeignKey("ClientId")]
        public virtual List<PrePurchaseWorks> PrePurchaseWorks { get; set; }
        [ForeignKey("ClientId")]
        public virtual List<ClientWishes> ClientWishes { get; set; }
    }
}
