using System.Text.Json.Serialization;

namespace ATMSystem.Models
{
    public class Account
    {
        
        public int AccountNumber { get; set; }  
        public string AccountType { get; set; } //enum
        public decimal Balance { get; set; }    
        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }

        [JsonIgnore]
        public ICollection<Transaction> Transactions { get; set; }


        [JsonIgnore]
        public ICollection<Card> Cards { get; set; }
    }
}

    