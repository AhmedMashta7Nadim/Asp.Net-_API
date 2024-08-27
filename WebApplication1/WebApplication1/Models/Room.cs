namespace WebApplication1.Models
{
    public class Room
    {
       

        public Room()
        {

        }

        public Room(int number, int floorNumber, Stetus status)
        {
            Number = number;
            FloorNumber = floorNumber;
            this.status = status;
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public int FloorNumber { get; set; }
        public Stetus status { get; set; }
        public int RoomTypeId { get; set; }
        //public int GuestId { get; set; }
        //public int BookingId { get; set; }
        public int HottelId { get; set; }
        public bool IsActive { get; set; } = true;

        public static Room AddRoom(int number, int floorNumber, Stetus status)
        {
            Room room=new Room(number, floorNumber, status);
            return room;
        }
    }
}
