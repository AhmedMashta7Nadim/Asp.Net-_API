using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Serves.functions
{
    public class FunctionDelete : IFunctionDelete
    {
        private readonly AdminContext context;

        public FunctionDelete(
            AdminContext context
            )
        {
            this.context = context;
        }

       

        public async Task<ActionResult<Hottel>> DeleteHottelAsync(int id)
        {
            var hottelDelete = context.hottels
                .SingleOrDefault(x => x.Id == id);
            Console.WriteLine(hottelDelete);
            if( hottelDelete != null )
            {
                hottelDelete.IsActive = false;
               context.SaveChanges();
                return hottelDelete;
            }
            return null;
        }

        public async Task<ActionResult<Room>> DeleteRoomAsync(int id)
        {
            var roomDelete = context.rooms
                .FirstOrDefault(x => x.Id == id && x.IsActive != false );
            if (roomDelete == null)
            {
                return null;
            }
            roomDelete.IsActive = false;
            context.SaveChanges();
            return roomDelete;
        }

        public Task<ActionResult<RoomType>> DeleteRoomTypeAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<ActionResult<Booking>> DeleteBookingAsync(int id)
        {
            var bookingDelete = context.bookings
                .FirstOrDefault(x => x.Id == id && x.IsActive != false);

            var Accessemployee = context.employees
                .FirstOrDefault(x => x.Id == bookingDelete.EmployeeId);


            if (bookingDelete == null || Accessemployee.IsActive==false)
            {
                return null;
            }
            bookingDelete.IsActive = false;
            context.SaveChanges();

            return bookingDelete;
        }

        public async Task<ActionResult<Guest>> DeleteGuestAsync(int id)
        {
            var guestsDelete = context.guests
                  .FirstOrDefault(x => x.Id == id && x.IsActive != false);
            if(guestsDelete == null)
            {
                return null;
            }
            guestsDelete.IsActive = false;
            context.SaveChanges();
            return guestsDelete;

        }

        public async Task<ActionResult<Employee>> DeleteEmployeeAsync(int id)
        {
            var employeeDelete = context.employees
                  .FirstOrDefault(x => x.Id == id && x.IsActive != false);
            if (employeeDelete == null)
            {
                return null;
            }
            employeeDelete.IsActive = false;
            context.SaveChanges();

            return employeeDelete;
        }
    }
}
