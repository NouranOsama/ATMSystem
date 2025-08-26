using System.Text.Json.Serialization;

namespace ATMSystem.Models
{
    public class Card
    {
        public int CardId { get; set; }
        public string CardNumber { get; set; }
        public string PinHash { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int AccountNumber { get; set; }

        [JsonIgnore]
        public Account Account { get; set; }
    }

}