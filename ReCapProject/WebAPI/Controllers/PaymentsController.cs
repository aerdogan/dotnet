using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        IBankCardService _bankCardService;

        public PaymentsController(IBankCardService bankCardService)
        {
            _bankCardService = bankCardService;
        }

        [HttpPost("payment")]
        public ActionResult Payment(BankCard bankCard, bool saveCard)
        {
            var result = _bankCardService.Checkout(bankCard, saveCard);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
