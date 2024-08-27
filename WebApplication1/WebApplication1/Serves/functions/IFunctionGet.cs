using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.VM;

namespace WebApplication1.Serves.functions
{
    public interface IFunctionGet
    {
        public Task<(int , List<Hottel>)> GetHottelsAsync(int Pn,int Pz);

        public Task<Hottel> GetHottelAsync(int hottelId, bool Inclode = false);
        ////////////////////////////////////////  Room 
        public Task<List<Room>> GetRoomsAsync(int Pn, int Pz);
        public Task<ActionResult<Room>> GetRoomAsync(int idroom);

        ////////////////////// Booking
        public Task<List<Booking>> GetBookings(int Pn, int Pz);
        ////////////////// Employee
        public Task<List<Employee>> GetEmployee(int Pn, int Pz);
        ////////////////////// Guest
        public Task<List<Guest>> GetGuests(int Pn, int Pz);


    }
}
