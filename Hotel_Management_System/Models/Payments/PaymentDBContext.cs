using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Models.Payments
{
    public class PaymentDBContext : DbContext
    {
        public PaymentDBContext(DbContextOptions<PaymentDBContext> picups) : base(picups)
        {
        }
        public DbSet<Payments> Payments { get; set; }
    }
}
