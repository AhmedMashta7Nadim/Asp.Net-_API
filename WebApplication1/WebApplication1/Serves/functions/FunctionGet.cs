using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Serves.functions
{
    public class FunctionGet : IFunctionGet
    {
        private readonly AdminContext context;
        private readonly int maxPage = 10;

        public FunctionGet(
            AdminContext context
            )
        {
            this.context = context;
        }


        public async Task<(int , List<Hottel>)> GetHottelsAsync(int Pn, int Pz)
        {
            if (maxPage < Pz)
            {
                Pz = maxPage;
            }
            var responce = await context.hottels
                .Where(x => x.IsActive)
                .Skip(Pz * (Pn - 1))
                .Take(Pz)
                .ToListAsync();
            return (context.hottels.Count(),responce);//تم تطبيق هنا مفهوم عرض عدد الصفحات وايضا الpageination 
        }

        public async Task<Hottel> GetHottelAsync(int hottelId, bool Inclode = true)
        {
            var responce = await context.hottels
                .FirstOrDefaultAsync(x => x.Id == hottelId && x.IsActive != false);
            if (responce == null)
            {
                return responce;
            }
            if (Inclode == true)
            {
                responce = await context.hottels
                                   .Where(x => x.IsActive == true)
                                   .Include(x => x.employees)
                                   .Include(x => x.rooms)
                                   .Include(x => x.guests)
                                   .FirstOrDefaultAsync();
            }
            return responce!;
        }

        public async Task<List<Booking>> GetBookings(int Pn, int Pz)
        {
            if (maxPage < Pz)
            {
                return null;
            }
            var result = await context.bookings
                .Where(x => x.IsActive == true)
                .Skip(Pz * (Pn - 1))
                .Take(Pz)
                .ToListAsync();

            return result;
        }
        public async Task<List<Room>> GetRoomsAsync(int Pn, int Pz)
        {
            if (maxPage < Pz)
            {
                return null;
            }
            var responce = await context.rooms
                .Where(x => x.IsActive == true)
                .Skip(Pz * (Pn - 1))
                .Take(Pz)
                .ToListAsync();

            return responce;
        }
        public Task<ActionResult<Room>> GetRoomAsync(int idroom)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Employee>> GetEmployee(int Pn, int Pz)
        {
            if (maxPage < Pz)
            {
                return null;
            }
            var getEmployee = await context.employees
                .Where(x => x.IsActive == true)
                .Skip(Pz * (Pn - 1))
                .Take(Pz)
                .ToListAsync();
            return getEmployee;
        }

        public async Task<List<Guest>> GetGuests(int Pn, int Pz)
        {
            if (maxPage < Pz)
            {
                return null;
            }
            var getGuest = await context.guests
               .Where(x => x.IsActive == true)
                .Skip(Pz * (Pn - 1))
                .Take(Pz)
               .ToListAsync();

            return getGuest;
        }
    }
}
