using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.VM
{
    public class GuestSummary
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int HottelId { get; set; }
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public bool IsActive { get; set; }
    }
}
