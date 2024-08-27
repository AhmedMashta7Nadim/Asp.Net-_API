using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Serves;
using WebApplication1.Serves.functions;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IFunctionGet get;
        private readonly IFunctionPost post;

        public PaymentController(
            IFunctionGet get,
            IFunctionPost post
            )
        {
            this.get = get;
            this.post = post;
        }

        [HttpPost]
       public async Task<ActionResult<Payment>> AddpaymentAsync(double Totalamount, DateTime CreateDate, int BookingId)
        {
            var insert=await post.Addpayment(Totalamount, CreateDate, BookingId);
            return insert;
        }
    }
}
