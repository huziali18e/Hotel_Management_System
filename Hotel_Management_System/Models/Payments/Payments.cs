using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace Hotel_Management_System.Models.Payments
{
    public class Payments
    {
        public int Id { get; set; }
        public string GuestName { get; set; }
        public string PaymentMethod { get; set; }
        [Column(TypeName =  "decimal(18,4)")]
        public decimal Amount { get; set; }
    }
}
