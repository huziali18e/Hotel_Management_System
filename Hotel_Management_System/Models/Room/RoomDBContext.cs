using Microsoft.EntityFrameworkCore;

namespace Hotel_Management_System.Models.Room
{
    public class RoomDBContext : DbContext
    {
        public RoomDBContext(DbContextOptions<RoomDBContext> options) : base(options)
        {
        }
        public DbSet<Room> Rooms { get; set; }
    }
}
