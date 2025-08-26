namespace ATMSystem.DTO
{
    public class CreateAtmDto
    {
        public string Location { get; set; } = string.Empty;
        public decimal InitialCash { get; set; }
        public string Status { get; set; } = "Active"; 
    }

    public class UpdateAtmDto
    {
        public string? Location { get; set; }
        public decimal? CashAvailable { get; set; }
        public string? Status { get; set; }
    }

    public class AtmResponseDto
    {
        public int AtmId { get; set; }
        public string Location { get; set; } = string.Empty;
        public decimal CashAvailable { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}