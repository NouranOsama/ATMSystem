using System.Text.Json.Serialization;

namespace ATMSystem.Models
{
    public class TransactionType
    {
        public int TransactionTypeId { get; set; }
        public string TypeName { get; set; }

        [JsonIgnore]
        public ICollection<Transaction> Transactions { get; set; }
    }


}
