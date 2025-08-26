using System.ComponentModel.DataAnnotations;

namespace ATMSystem.DTOs
{
    public class CreateCardDto
    {
        public int CardNumber { get; set; }
        [Required]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "PIN code must be exactly 4 digits")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "PIN code must be 4 numeric digits only")]
        public string PinCode { get; set; }
        public int AccountNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
