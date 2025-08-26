using System.Text.Json.Serialization;

namespace ATMSystem.Models 
{
    public class ATM
    {
        public int AtmId { get; set; }
        public string Location { get; set; }
        public decimal CashAvailable { get; set; }
        public string Status { get; set; } // state design pattern

        [JsonIgnore]
        public ICollection<Transaction> Transactions { get; set; }
    }

}

