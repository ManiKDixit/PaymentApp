using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PaymentsApi.Data;
using PaymentsApi.Interfaces;
using PaymentsApi.Models;

namespace PaymentsApi.Repository
{
    public class PaymentRepository : IPaymentRepository
    {

        private readonly IMongoCollection<PaymentDetails> _paymentCollection;

        public PaymentRepository(IOptions<MongoDbSettings> mongoDbSettings)
        {

            var mongoClient = new MongoClient(mongoDbSettings.Value.ConnectionURI);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.Value.DatabaseName);
            _paymentCollection = mongoDatabase.GetCollection<PaymentDetails>(mongoDbSettings.Value.CollectionName);

        }

        public async Task AddCardOwnerDetails(PaymentDetails paymentDetails)
        {
            await _paymentCollection.InsertOneAsync(paymentDetails);
        }

        public async Task DeleteCardOwnerDetails(string id)
        {
            await _paymentCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<PaymentDetails>> GetAllDetails()
        {
            return await _paymentCollection.Find(_ => true).ToListAsync();
        }

        public async Task<PaymentDetails> GetCardDetailsById(string id)
        {
            return await _paymentCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateCardOwnerDetails(string id, PaymentDetails paymentDetails)
        {
            await _paymentCollection.ReplaceOneAsync(x => x.Id == id, paymentDetails);
        }
    }
}
