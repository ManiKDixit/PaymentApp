using Microsoft.AspNetCore.Mvc;
using PaymentsApi.Interfaces;
using PaymentsApi.Models;
using PaymentsApi.Repository;

namespace PaymentsApi.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;

        }

        [HttpGet]
        [RequireHttps]
        public async Task<List<PaymentDetails>> GetAllDetails()
        {
            return await _paymentRepository.GetAllDetails();
        }

        [HttpGet("{id}")]
        [RequireHttps]
        public async Task<PaymentDetails> GetCardDetailsById(string id)
        {
            return await _paymentRepository.GetCardDetailsById(id);
        }


        [HttpPost]
        [RequireHttps]
        public async Task<IActionResult> AddCardOwnerDetails([FromBody] PaymentDetails paymentDetails)
        {
           

            await _paymentRepository.AddCardOwnerDetails(paymentDetails);
            CreatedAtAction(nameof(GetAllDetails), new
            {
                id = paymentDetails.Id
            }, paymentDetails);

            return Ok(await _paymentRepository.GetAllDetails());
        }

        


        [HttpPut("{id}")]
        [RequireHttps]
        public async Task<IActionResult> UpdateCardOwnerDetails(string id, [FromBody] PaymentDetails paymentDetails)
        {
            await _paymentRepository.UpdateCardOwnerDetails(id,paymentDetails);
            return Ok(await _paymentRepository.GetAllDetails());
        }




        [HttpDelete("{id}")]
        [RequireHttps]
        public async Task<IActionResult> DeleteCardOwnerDetails(string id)
        {
            await _paymentRepository.DeleteCardOwnerDetails(id);
            return Ok(await _paymentRepository.GetAllDetails());
        }
    }
}
