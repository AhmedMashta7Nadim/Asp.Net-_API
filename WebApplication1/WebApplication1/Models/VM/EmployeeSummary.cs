using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.VM
{
    public class EmployeeSummary
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public DateTime StartedDate { get; set; }
        public int HottelId { get; set; }

    }
}
