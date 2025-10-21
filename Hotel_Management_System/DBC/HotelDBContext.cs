using Hotel_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.DBC
{
    public class HotelDBContext : DbContext
    {
        internal readonly object Guests;

        public HotelDBContext(DbContextOptions<HotelDBContext> options) : base(options)
        {
        }

        public DbSet<Guests> Hotel { get; set; }
    }
}
