namespace ATMSystem.DTOs
{
    public class TransactionRequestDto
    {
        public int CardId { get; set; }
        public string PinCode { get; set; }
        public int AtmId { get; set; }
        public decimal Amount { get; set; }
    }

    public class TransactionResponseDto
    {
        public int TransactionId { get; set; }
        public int AccountNumber { get; set; }
        public int AtmId { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string TransactionType { get; set; }
    }
}
