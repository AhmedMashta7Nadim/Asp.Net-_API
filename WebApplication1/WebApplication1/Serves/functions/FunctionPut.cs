using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Serves.functions
{
    public class FunctionPut : IFunctionPut
    {
        private readonly AdminContext context;
        private readonly IMapper mapper;

        public FunctionPut(
            AdminContext context,
            IMapper mapper
            )
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Booking> PutBookingAsync(int id, DateTime CheckinAt, DateTime CheckOutAt, double price, int EmployeeId, bool IsActive)
        {
            var putbooking = context.bookings
                 .FirstOrDefault(x => x.Id == id);
            
            
            if (putbooking == null)
            {
                return null;
            }

            putbooking.CheckOutAt = CheckOutAt;
            putbooking.CheckinAt= CheckinAt;
            putbooking.Price= price;
            putbooking.EmployeeId= EmployeeId;
            putbooking.IsActive=IsActive;

            context.SaveChanges();

            return putbooking;
        }

        public async Task<Employee> PutEmployeeAsync(int id, string firstName, string lastName, string title, DateTime dOB, string email, DateTime startedDate, int HottelId, bool IsActive)
        {
            var putemplyee = context.employees
                .FirstOrDefault(x => x.Id == id);
            if (putemplyee == null)
            {
                return null;
            }
            putemplyee.FirstName = firstName;
            putemplyee.LastName = lastName;
            putemplyee.Title = title;
            putemplyee.DOB = dOB;
            putemplyee.Email = email;
            putemplyee.StartedDate = startedDate;
            putemplyee.HottelId = HottelId;
            putemplyee.IsActive = IsActive;
            context.SaveChanges();
            return putemplyee;

        }

        public async Task<Guest> PutGuestAsync(int id, string firstName, string lastName, DateTime dOB, string email, string phone, int HottelId, int BookingId, int RoomId,bool isActive)
        {
            var putguest = context.guests
                .FirstOrDefault(x => x.Id == id);
            if(putguest == null)
            {
                return null;
            }
            putguest.Phone = phone;
            putguest.FirstName = firstName;
            putguest.LastName = lastName;
            putguest.Email = email;
            putguest.IsActive=isActive;
            putguest.DOB = dOB;
            putguest.RoomId = RoomId;
            putguest.HottelId = HottelId;
            putguest.BookingId = BookingId;

            context.SaveChanges();
            return putguest;
        }

        public async Task<Hottel> PutHottelAsync(int id, string name, string email, string phone, string address,bool isActive)
        {
            var puthottel = context.hottels.FirstOrDefault(x => x.Id == id);
            if (puthottel == null)
            {
                return null;
            }
            puthottel.Name = name;
            puthottel.Email = email;
            puthottel.Phone = phone;
            puthottel.Address = address;
            puthottel.IsActive = isActive;
            context.SaveChanges();

            return puthottel;
        }

        public async Task<Room> PutRoomAsync(int id, int number, int floorNumber, Stetus status, int RoomTypeId, int HottelId, bool IsActive)
        {
            var putroom = context.rooms
                .FirstOrDefault(x => x.Id == id);
            if (putroom == null)
            {
                return null;
            }
            putroom.status = status;
            putroom.Number = number;
            putroom.FloorNumber = floorNumber;
            putroom.IsActive = IsActive;
            putroom.RoomTypeId = RoomTypeId;
            putroom.HottelId = HottelId;
            context.SaveChanges();

            return putroom;


        }
    }
}
