using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Serves;
using WebApplication1.Serves.functions;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IFunctionGet get;
        private readonly IFunctionPost post;

        public RoomTypeController(
            IFunctionGet get,
            IFunctionPost post
            )
        {
            this.get = get;
            this.post = post;
        }
        [HttpPost("{numOf}/{Typename}")]
        public async Task<ActionResult<RoomType>> AddRoomTypeAsync(int numOf,string Typename)
        {
            var responce=await post.AddRoomTypeAsync(numOf, Typename);

            if (responce == null)
            {
                return NotFound();
            }

            return Ok(responce);

        }


    }
}
