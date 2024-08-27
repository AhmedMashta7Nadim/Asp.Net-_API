using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Serves.functions
{
    public interface IFunctionDelete
    {
        Task<ActionResult<Hottel>> DeleteHottelAsync(int id);
        Task<ActionResult<Room>> DeleteRoomAsync(int id);
        Task<ActionResult<Booking>> DeleteBookingAsync(int id);
        Task<ActionResult<Employee>> DeleteEmployeeAsync(int id);
        Task<ActionResult<Guest>> DeleteGuestAsync(int id);
        Task<ActionResult<RoomType>> DeleteRoomTypeAsync(int id);
    }
}
