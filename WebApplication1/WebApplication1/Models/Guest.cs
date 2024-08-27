using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Guest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        public Hottel Hottel { get; set; }
        public int HottelId { get; set; }
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
        public bool IsActive { get; set; } = true;


        public static Guest AddGuest(string firstName, string lastName, DateTime dOB, string email, string phone)
        {
            Guest guest = new Guest
            {
                FirstName = firstName,
                LastName = lastName,
                DOB = dOB,
                Email = email,
                Phone = phone
            };
            return guest;
        }

    }
}
