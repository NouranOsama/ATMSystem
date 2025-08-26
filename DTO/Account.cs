namespace ATMSystem.DTOs
{
    public class CreateAccountDto
    {
        public int CustomerId { get; set; }
        public string AccountType { get; set; }
        public decimal InitialBalance { get; set; }
    }
}
