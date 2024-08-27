using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.VM;
using WebApplication1.Serves;
using WebApplication1.Serves.functions;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RoomController : ControllerBase
    {

        private readonly IFunctionGet get;
        private readonly IFunctionPost post;
        private readonly IFunctionDelete delete;
        private readonly IMapper mapper;
        private readonly IFunctionPut put;
        private readonly IFunctionUpdate update;

        public RoomController(
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
        public async Task<ActionResult<RoomSummary>> GetRoomsAsync(int pageNumber, int pageSize)
        {
            var responce= await get.GetRoomsAsync(pageNumber,pageSize);
            if (responce == null)
            {
                return NotFound();
            }
            var roomsummary = mapper.Map<List<RoomSummary>>(responce);
            return Ok(roomsummary);
        }



        [HttpPost]
        public async Task<ActionResult<Room>> AddRoomAsync(int number, int floorNumber, Stetus status,int roomType,int HottelId)
        {
            var addroom =await post.AddRoomAsync(number, floorNumber, status,roomType,HottelId);
            if (addroom == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetRoomsAsync), new { id = addroom.Id }, addroom);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Room>> DeleteRoomAsync(int id)
        {
            var deleted=await delete.DeleteRoomAsync(id);
            if (delete == null)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
        [HttpPut]
        public async Task<ActionResult<Room>> PutRoomAsync(int id, int number, int floorNumber, Stetus status, int RoomTypeId, int HottelId, bool IsActive)
        {
            var putroom=put.PutRoomAsync(id,number,floorNumber,status,RoomTypeId,HottelId,IsActive);
            if(putroom == null)
            {
                return NoContent();
            }
            return Ok(putroom);
        }
        [HttpPatch("update/{id}")]
        public async Task<ActionResult<RoomSummary>> UpdateGuestAsync(int id, JsonPatchDocument<RoomSummary> room)
        {
            var updateroom = update.UpdateRoomAsync(id, room);
            if (updateroom == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
