using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Employee
    {
        public Employee(string firstName, string lastName, string title, DateTime dOB, string email, DateTime startedDate/* Hottel hottel,*/)
        {
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            DOB = dOB;
            Email = email;
            StartedDate = startedDate;
            //Hottel = hottel;
        }

        public Employee()
        {
            
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime StartedDate { get; set; }
        public Hottel Hottel { get; set; }
        public int HottelId { get; set; }
        public bool IsActive { get; set; } = true;

        public List<Booking> bookings { get; set; } = new List<Booking>();
        public static Employee AddEmployee(string firstName, string lastName, string title, DateTime dOB, string email, DateTime startedDate/*, Hottel hottel*/)
        {
            Employee employee=new Employee(firstName, lastName, title, dOB, email, startedDate/* hottel,*/);
            return employee;
        }
    }
}
