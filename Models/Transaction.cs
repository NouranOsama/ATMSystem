using System.Text.Json.Serialization;

namespace ATMSystem.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string Status { get; set; }
        public int TransactionTypeId { get; set; }

        [JsonIgnore]
        public TransactionType TransactionType { get; set; }
        public int AccountNumber { get; set; }

        [JsonIgnore]
        public Account Account { get; set; }
        public int? AtmId { get; set; }

        [JsonIgnore]
        public ATM ATM { get; set; }
    }

}
