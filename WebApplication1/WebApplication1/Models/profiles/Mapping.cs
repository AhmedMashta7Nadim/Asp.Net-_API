using AutoMapper;
using WebApplication1.Models.VM;

namespace WebApplication1.Models.profiles
{
    public class Mapping:Profile
    {
        public Mapping()
        {

            CreateMap<Hottel, HottelSummary>();
            CreateMap<HottelSummary, Hottel>();

            CreateMap<Employee, EmployeeSummary>();
            CreateMap<EmployeeSummary, Employee>();

            CreateMap<Guest, GuestSummary>();
            CreateMap<GuestSummary,Guest >();

            CreateMap<Booking, BookingSummary>();
            CreateMap<BookingSummary,Booking>();

            CreateMap<Room, RoomSummary>();
            CreateMap<RoomSummary,Room >();

        }
    }
}
