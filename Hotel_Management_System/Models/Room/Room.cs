using System.ComponentModel.DataAnnotations;

namespace Hotel_Management_System.Models.Room
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string RoomType { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
