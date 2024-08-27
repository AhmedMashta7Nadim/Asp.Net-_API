using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.VM;
using WebApplication1.Serves.functions;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IFunctionGet get;
        private readonly IFunctionPost post;
        private readonly IFunctionDelete delete;
        private readonly IMapper mapper;
        private readonly IFunctionPut put;
        private readonly IFunctionUpdate update;

        public GuestController(
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
        [HttpGet("getGuest/")]
        public async Task<ActionResult<List<GuestSummary>>> GetGuestAsync(int pageNumber, int pageSize)
        {
            var getGusets = await get.GetGuests(pageNumber,pageSize);
            if(getGusets == null) {
                return BadRequest();
            }
            var guestsummer = mapper.Map<List<GuestSummary>>(getGusets);
            return Ok(guestsummer);
        }

        [HttpPost]
        public async Task<ActionResult<Guest>> AddGuestAsync(string firstName, string lastName, DateTime dOB, string email, string phone, int HottelId, int BookingId, int RoomId)
        {
            var insert = await post.AddGuest(firstName, lastName, dOB, email, phone, HottelId, BookingId, RoomId);

            return CreatedAtAction(nameof(GetGuestAsync), new { id = insert.Id }, insert);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guest>> DeleteGuestAsync(int id)
        {
            var Deleteguest = await delete.DeleteGuestAsync(id);
            if (Deleteguest == null)
            {
                return NotFound();
            }
            return Ok(Deleteguest);
        }
        [HttpPut("Edit Guest")]
        public async Task<ActionResult<Guest>> PutGuestAsync(int id, string firstName, string lastName, DateTime dOB, string email, string phone, int HottelId, int BookingId, int RoomId, bool isActive)
        {
            var putguest = put.PutGuestAsync(id, firstName, lastName, dOB, email, phone, HottelId, BookingId, RoomId, isActive);
            if (putguest == null)
            {
                return NoContent();
            }
            return Ok(putguest);
        }

        [HttpPatch("update/{id}")]
        public async Task<ActionResult<GuestSummary>> UpdateGuestAsync(int id, JsonPatchDocument<GuestSummary> guest)
        {
            var updateguest=update.UpdateGuestAsync(id, guest);
            if (updateguest == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
