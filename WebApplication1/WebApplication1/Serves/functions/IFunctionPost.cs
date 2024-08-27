using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Serves.functions
{
    public interface IFunctionPost
    {
        public Task<Hottel> AddHottelAsync
            (string name, string email, string phone, string address);
        ///////////// Room
        public Task<Room> AddRoomAsync(int number, int floorNumber, Stetus status, int r, int HottelId);
        ////////////////// Room Type
        public Task<RoomType> AddRoomTypeAsync(int numberOfbaounds, string typename);
        ///////// Booking
        public Task<Booking> AddBooking(DateTime CheckinAt, DateTime CheckOutAt, double price,int EmployeeId);
        //////////// Payment
        public Task<Payment> Addpayment(double Totalamount, DateTime CreateDate, int BookingId);
        /////////// Employee
        public Task<Employee> AddEmployee(string firstName, string lastName, string title, DateTime dOB, string email, DateTime startedDate, int HottelId);
        ///////////// Guest
        public Task<Guest> AddGuest(string firstName, string lastName, DateTime dOB, string email, string phone, int HottelId, int BookingId,int RoomId);

    }
}
