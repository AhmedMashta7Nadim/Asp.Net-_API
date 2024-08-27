using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IFunctionGet get;
        private readonly IFunctionPost post;
        private readonly IFunctionDelete delete;
        private readonly IMapper mapper;
        private readonly IFunctionPut put;
        private readonly IFunctionUpdate update;

        public EmployeeController(
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
        public async Task<ActionResult<List<Employee>>> GetEmployees(int pageNumber, int pageSize)
        {
            var getEmployees =await get.GetEmployee(pageNumber,pageSize);

            var employeesummary = mapper.Map<List<EmployeeSummary>>(getEmployees);

            if (getEmployees == null)
            {
                return NotFound();
            }
            return Ok(employeesummary);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployeeAsync(string firstName, string lastName, string title, DateTime dOB, string email, DateTime startedDate, int HottelId)
        {
            var insert=await post.AddEmployee(firstName, lastName, title, dOB, email, startedDate, HottelId);
            if(insert == null)
            {
                return StatusCode(404,"as");
            }
            return CreatedAtAction(nameof(GetEmployees), new { id = insert.Id }, insert);
        }
        [HttpDelete("Delete/{id}")]
        
        public async Task<ActionResult<Employee>> DeleteEmployeeAsync(int id)
        {
            var employeeDelete= await delete.DeleteEmployeeAsync(id);
            if (employeeDelete == null)
            {
                return NotFound();
            }
            return Ok(employeeDelete);
        }
        [HttpPut("Edit employee/{id}")]
        public async Task<ActionResult<Employee>> PutEmployeeAsync(int id, string firstName, string lastName, string title, DateTime dOB, string email, DateTime startedDate, int HottelId, bool IsActive)
        {
                var puthottel=await put.PutEmployeeAsync(id, firstName, lastName, title, dOB,email, startedDate, HottelId, IsActive);
            if (puthottel == null)
            {
                return NoContent();
            }
            return Ok(puthottel);
        }
        [HttpPatch("update/{id}")]
        public async Task<ActionResult<EmployeeSummary>> UpdateGuestAsync(int id, JsonPatchDocument<EmployeeSummary> employee)
        {
            var updateemployee = update.UpdateEmployeeAsync(id, employee);
            if (employee == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
