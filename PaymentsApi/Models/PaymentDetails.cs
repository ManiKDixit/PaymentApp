using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PaymentsApi.Models
{
    public class PaymentDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string CardOwnerName { get; set; }

        
        public string CardNumber { get; set; }

        
        public string ExpirationDate { get; set; }

       
        public int SecurityCode { get; set; }

        public string AccountBalance { get; set; }
    }
}
