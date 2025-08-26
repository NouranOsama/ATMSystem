 using System.Threading.Tasks;
using ATMSystem.DTOs;
using ATMSystem.Models;

namespace ATMSystem.Services.Interfaces
{
    public interface ICardService
    {
        Task<Card> CreateCardAsync(CreateCardDto dto);
        Task<bool> VerifyPinAsync(int cardId, string pinCode);
        Task<Card?> GetCardByIdAsync(int cardId);
        Task<bool> DeleteCardAsync(int cardId);

    }
}
