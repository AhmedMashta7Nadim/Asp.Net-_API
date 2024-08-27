using Microsoft.AspNetCore.JsonPatch;
using WebApplication1.Models;
using WebApplication1.Models.VM;

namespace WebApplication1.Serves.functions
{
    public interface IFunctionUpdate
    {
        Task<Hottel> UpdateHottelAsync(int id,JsonPatchDocument<HottelSummary> hottel);
        Task<Room> UpdateRoomAsync(int id, JsonPatchDocument<RoomSummary> patchDocument);
        Task<Booking> UpdateBookingAsync(int id, JsonPatchDocument<BookingSummary> patchDocument);
        Task<Employee> UpdateEmployeeAsync(int id, JsonPatchDocument<EmployeeSummary> patchDocument);
        Task<Guest> UpdateGuestAsync(int id, JsonPatchDocument<GuestSummary> patchDocument);
    }
}
