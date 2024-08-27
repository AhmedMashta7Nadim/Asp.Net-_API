using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Serves.functions
{
    public interface IFunctionPut
    {
        Task<Hottel> PutHottelAsync(int id, string name, string email, string phone, string address,bool isActive);
        Task<Room> PutRoomAsync(int id,int number, int floorNumber, Stetus status, int RoomTypeId, int HottelId,bool IsActive);
        Task<Booking> PutBookingAsync(int id, DateTime CheckinAt, DateTime CheckOutAt, double price, int EmployeeId,bool IsActive);
        Task<Employee> PutEmployeeAsync(int id, string firstName, string lastName, string title, DateTime dOB, string email, DateTime startedDate, int HottelId,bool IsActive);
        Task<Guest> PutGuestAsync(int id, string firstName, string lastName, DateTime dOB, string email, string phone, int HottelId,int BookingId,int RoomId,bool isActive);
    }
}
