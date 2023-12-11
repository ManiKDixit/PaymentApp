using PaymentsApi.Models;

namespace PaymentsApi.Interfaces
{
    public interface IPaymentRepository
    {
        public Task<List<PaymentDetails>> GetAllDetails();
        public Task<PaymentDetails> GetCardDetailsById(string id);
        public Task AddCardOwnerDetails(PaymentDetails paymentDetails);
        public Task UpdateCardOwnerDetails(string id, PaymentDetails paymentDetails);
        public Task DeleteCardOwnerDetails(string id);
    }
}
