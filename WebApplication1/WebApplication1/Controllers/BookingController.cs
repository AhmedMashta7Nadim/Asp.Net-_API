using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Models.VM;
using WebApplication1.Serves;
using WebApplication1.Serves.functions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IFunctionGet get;
        private readonly IFunctionPost post;
        private readonly IFunctionDelete delete;
        private readonly IMapper mapper;
        private readonly IFunctionPut put;
        private readonly IFunctionUpdate update;

        public BookingController(
            IFunctionGet get,
            IFunctionPost post,
            IFunctionDelete delete,
            IMapper mapper,
            IFunctionPut put,
            IFunctionUpdate update
            )
        {
            this.get = get;
            this.post = post;
            this.delete = delete;
            this.mapper = mapper;
            this.put = put;
            this.update = update;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<BookingSummary>>> GetBookingsync(int pageNumber,int pageSize)
        {
            var resultAll = await get.GetBookings(pageNumber,pageSize);
            if (resultAll == null)
            {
                return BadRequest();
            }
            var bookingsummary = mapper.Map<List<BookingSummary>>(resultAll);
            return Ok(bookingsummary);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> AddBooking(DateTime CheckinAt, DateTime CheckOutAt, double price,int EmployeeId)
        {
            var insert=await post.AddBooking(CheckinAt, CheckOutAt, price, EmployeeId);
            if (insert == null)
            {
                return StatusCode(404,"error is Not Employee");
            }

            return CreatedAtAction(nameof(GetBookingsync), new { id = insert.Id }, insert);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Booking>> DeleteBookingAsync(int id)
        {
            var deleteBooking=delete.DeleteBookingAsync(id);
            if (deleteBooking == null)
            {
                return NotFound();
            }
            return Ok(deleteBooking);
        }
        [HttpPut("Edit Booking")]
        public async Task<ActionResult<Booking>> PutBookingAsync(int id, DateTime CheckinAt, DateTime CheckOutAt, double price, int EmployeeId, bool IsActive)
        {
            var putbooking=await put.PutBookingAsync(id, CheckinAt, CheckOutAt, price,EmployeeId,IsActive);
            if(putbooking == null)
            {
                return NoContent();
            }
            return Ok(putbooking);
        }
        [HttpPatch("update/{id}")]
        public async Task<ActionResult<BookingSummary>> UpdateGuestAsync(int id, JsonPatchDocument<BookingSummary> booking)
        {
            var updatebooking = update.UpdateBookingAsync(id, booking);
            if (booking == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
