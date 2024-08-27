using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Payment
    {
      
        public Payment()
        {
            
        }
        public int Id { get; set; }
        public double Totalamount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BookingId { get; set; }
        public bool IsActive { get; set; } = true;



    }
}
