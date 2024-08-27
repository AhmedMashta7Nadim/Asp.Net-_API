using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace WebApplication1.Models
{
    public class Booking
    {

        public Booking()
        {

        }
        public int Id { get; set; }
        public DateTime CheckinAt { get; set; }
        public DateTime CheckOutAt { get; set; }
        public double Price { get; set; }

        public List<Payment> payments { get; set; } = new List<Payment>();
        //public Room room { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public bool IsActive { get; set; } = true;

        public static Booking AddBooking(DateTime CheckinAt, DateTime CheckOutAt, double price, List<Payment> payments, Employee employee)
        {
            Booking booking = new Booking()
            {
                CheckinAt = CheckinAt,
                CheckOutAt = CheckOutAt,
                Price = price,
                Employee = employee,
                payments = payments,
            };
            return booking;
        }



    }
}
