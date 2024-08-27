namespace WebApplication1.Models.VM
{
    public class RoomSummary
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int FloorNumber { get; set; }
        public Stetus status { get; set; }
        public int RoomTypeId { get; set; }
        public int HottelId { get; set; }
        public bool IsActive { get; set; }

    }
}
