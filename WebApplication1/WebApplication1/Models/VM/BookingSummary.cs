namespace WebApplication1.Models.VM
{
    public class BookingSummary
    {
        public int Id { get; set; }
        public DateTime CheckinAt { get; set; }
        public DateTime CheckOutAt { get; set; }
        public double Price { get; set; }
        public int EmployeeId { get; set; }
        public bool IsActive { get; set; } 
    }
}
