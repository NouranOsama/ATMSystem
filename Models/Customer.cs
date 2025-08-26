using ATMSystem.Data.UnitOfWork;
using System.Text.Json.Serialization;

namespace ATMSystem.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        [JsonIgnore]
        public virtual  ICollection<Account> Accounts { get; set; }
        
    }

}