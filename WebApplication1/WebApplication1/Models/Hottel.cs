using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Hottel
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public List<Employee> employees { get; set; } = new List<Employee>();
        public List<Room> rooms { get; set; } = new List<Room>();
        public List<Guest> guests { get; set; } = new List<Guest>();
        public bool IsActive { get; set; } = true;




    }
}
