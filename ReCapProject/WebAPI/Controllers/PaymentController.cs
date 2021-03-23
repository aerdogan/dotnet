using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("payment")]
        public ActionResult Payment()
        {
            Random rng = new Random();
            bool result = rng.Next(0, 2) > 0;
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
