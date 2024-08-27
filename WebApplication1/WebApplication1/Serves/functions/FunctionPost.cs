using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Serves.functions
{
    public class FunctionPost : IFunctionPost
    {
        private readonly AdminContext context;

        public FunctionPost(
            AdminContext context
            )
        {
            this.context = context;
        }

        public async Task <Booking> AddBooking (DateTime CheckinAt, DateTime CheckOutAt, double price, int EmployeeId)
        {
            var Access =  context.employees
              .FirstOrDefault(x => x.Id == EmployeeId && x.IsActive == true);
            if (Access == null)
            {
                return null;
            }
            Booking booking = new Booking()
            {
                CheckinAt = CheckinAt,
                CheckOutAt = CheckOutAt,
                Price = price,
                EmployeeId = EmployeeId
            };
          

             context.bookings.Add(booking);
             context.SaveChanges();
            return booking;
        }


        public async Task<Employee> AddEmployee(string firstName, string lastName, string title, DateTime dOB, string email, DateTime startedDate, int HottelId)
        {
            Employee employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Title = title,
                DOB = dOB,
                Email = email,
                StartedDate = startedDate,
                HottelId = HottelId
            };
            await context.employees.AddAsync(employee);
            await context.SaveChangesAsync();

            return employee;

        }

        public async Task<Guest> AddGuest(string firstName, string lastName, DateTime dOB, string email, string phone, int HottelId, int BookingId, int RoomId)
        {
            Guest guest = new Guest()
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                DOB = dOB,
                Email = email,
                HottelId = HottelId,
                BookingId = BookingId,
                RoomId= RoomId
            };
            var AccessRoom =  context.rooms
                .FirstOrDefault(x=>x.Id==RoomId && x.IsActive == true && x.status == Stetus.ready);
            if (AccessRoom == null)
            {
                return null;
            }
            else
            {
                AccessRoom.status = Stetus.occupied;
            }
            await context.guests.AddAsync(guest);
            await context.SaveChangesAsync();

            return guest;
        }

        public async Task<Hottel> AddHottelAsync(string name, string email, string phone, string address)
        {
            Hottel hottel = new Hottel()
            {
                Name = name,
                Email = email,
                Address = address,
                Phone = phone,
            };
            context.hottels.Add(hottel);
            context.SaveChanges();

            return hottel;
        }

        public async Task<Payment> Addpayment(double Totalamount, DateTime CreateDate, int BookingId)
        {
            Payment payment = new Payment()
            {
                Totalamount = Totalamount,
                CreatedDate = CreateDate,
                BookingId = BookingId
            };
            await context.payments.AddAsync(payment);
            await context.SaveChangesAsync();
            return payment;
        }






        public async Task<Room> AddRoomAsync(int number, int floorNumber, Stetus status, int r, int HottelId)
        {
            Room room = new Room()
            {
                Number = number,
                FloorNumber = floorNumber,
                status = status,
                RoomTypeId = r,
                HottelId = HottelId
            };
            var Access = await context.hottels.
                FirstOrDefaultAsync(x => x.Id == HottelId && x.IsActive == true);

           

           

            if (Access==null)
            {
                return null;
            }

            await context.rooms.AddAsync(room);
            await context.SaveChangesAsync();

            return room;
        }

        public async Task<RoomType> AddRoomTypeAsync(int numberOfbaounds, string typename)
        {
            RoomType roomType = new RoomType()
            {
                NumOfBands = numberOfbaounds,
                TypeName = typename,
            };
            await context.roomTypes.AddAsync(roomType);
            await context.SaveChangesAsync();

            return roomType;
        }

       
    }
}
