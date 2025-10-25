using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Models.Booking
{
    public class BookingDBContext : DbContext
    {
        public BookingDBContext(DbContextOptions<BookingDBContext> chioces) : base(chioces)
        {
        }
        public DbSet<Booking> Bookings { get; set; }
    }
}
