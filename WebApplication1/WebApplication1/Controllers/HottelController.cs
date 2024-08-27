using AutoMapper;
using Azure;
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
    public class HottelController : ControllerBase
    {
        private readonly ILogger<Hottel> logger;
        private readonly IFunctionGet get;
        private readonly IFunctionPost post;
        private readonly IFunctionDelete delete;
        private readonly IMapper mapper;
        private readonly IFunctionPut put;
        private readonly IFunctionUpdate update;

        public HottelController(
            ILogger<Hottel> _logger,
            IFunctionGet get,
            IFunctionPost post,
            IFunctionDelete delete,
            IMapper mapper,
            IFunctionPut put,
            IFunctionUpdate update
            )
        {
            logger = _logger;
            this.get = get;
            this.post = post;
            this.delete = delete;
            this.mapper = mapper;
            this.put = put;
            this.update = update;
        }

        [AllowAnonymous]
        [HttpGet("GetHottels")]
        public async Task<ActionResult<List<HottelSummary>>> GetHottels(int pageNumber, int pageSize)
        {
            var responce = await get.GetHottelsAsync(pageNumber, pageSize);

            Response.Headers.Add("Count", responce.Item1.ToString());

            var Hottelsummary = mapper.Map<List<HottelSummary>>(responce.Item2);
            return Ok(Hottelsummary);
        }

        [AllowAnonymous]
        [HttpGet("{idhottel}", Name = "GetHottel")]
        public async Task<ActionResult<Hottel>> GetHottel(int idhottel)
        {
            var responce = await get.GetHottelAsync(idhottel, false);
            if (responce == null)
            {
                return NotFound();
            }

            return Ok(responce);
        }

        [HttpPost("CreateHottel/{name}/{email}/{phone}/{address}")]
        public async Task<ActionResult<Hottel>> AddHottel(string name, string email, string phone, string address)
        {
            var request = await post.AddHottelAsync(name, email, phone, address);
            if (request == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetHottel), new { id = request.Id }, request);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Hottel>> DeleteHottel(int id)
        {
            var deleted = delete.DeleteHottelAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpPut("Edit Hottel")]
        public async Task<ActionResult<Hottel>> PutHottelAsync(int id, string name, string email, string phone, string address, bool isActive)
        {
            var puthottel = put.PutHottelAsync(id, name, email, phone, address, isActive);
            if (puthottel == null)
            {
                return NoContent();
            }
            return Ok(puthottel);
        }
        [HttpPatch("Update/{id}")]
        public async Task<ActionResult<HottelSummary>> UpdateHottelAsync(int id, JsonPatchDocument<HottelSummary> hottel)
        {
            var updatehottel = update.UpdateHottelAsync(id, hottel);

            if (updatehottel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
