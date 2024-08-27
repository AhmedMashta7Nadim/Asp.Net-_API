using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.VM;

namespace WebApplication1.Serves.functions
{
    public class FunctionUpdate:IFunctionUpdate
    {
        private readonly AdminContext context;
        private readonly IMapper mapper;

        public FunctionUpdate(
            AdminContext context,
            IMapper mapper
            )
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Booking> UpdateBookingAsync(int id, JsonPatchDocument<BookingSummary> patchDocument)
        {
            var booking = context.bookings
               .FirstOrDefault(x => x.Id == id);
            if (booking == null)
            {
                return null;
            }

            var mapping = mapper.Map<BookingSummary>(booking);

            patchDocument.ApplyTo(mapping);

            var added = mapper.Map(mapping, booking);

            context.SaveChanges();

            return added;
        }

        public async Task<Employee> UpdateEmployeeAsync(int id, JsonPatchDocument<EmployeeSummary> patchDocument)
        {
            var employee = context.employees
              .FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return null;
            }

            var mapping = mapper.Map<EmployeeSummary>(employee);

            patchDocument.ApplyTo(mapping);

            var added = mapper.Map(mapping, employee);

            context.SaveChanges();

            return added;
        }

        public async Task<Guest> UpdateGuestAsync(int id, JsonPatchDocument<GuestSummary> patchDocument)
        {
            var guest = context.guests
                .FirstOrDefault(x => x.Id == id);
            if (guest == null)
            {
                return null;
            }

            var mapping=mapper.Map<GuestSummary>(guest);

            patchDocument.ApplyTo(mapping);

           var added= mapper.Map(mapping,guest);

            context.SaveChanges();

           return added;
        }

        public async Task<Hottel> UpdateHottelAsync(int id, JsonPatchDocument<HottelSummary> patchDocument)
        {
            var exist =  context.hottels.FirstOrDefault(x => x.Id == id);

            if (exist == null)
            {
                return null;
            }

            var hottelSummary = mapper.Map<HottelSummary>(exist);

            patchDocument.ApplyTo(hottelSummary);

            mapper.Map(hottelSummary, exist);

             context.SaveChanges();

            return exist;
        }
        public async Task<Room> UpdateRoomAsync(int id, JsonPatchDocument<RoomSummary> patchDocument)
        {
            var room = context.rooms
               .FirstOrDefault(x => x.Id == id);
            if (room == null)
            {
                return null;
            }

            var mapping = mapper.Map<RoomSummary>(room);

            patchDocument.ApplyTo(mapping);

            var added = mapper.Map(mapping, room);

            context.SaveChanges();

            return added;
        }
    }
}
