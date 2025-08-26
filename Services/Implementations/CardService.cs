using ATMSystem.Data.Interfaces;
using ATMSystem.DTOs;
using ATMSystem.Models;
using ATMSystem.Services.Interfaces;
using BCrypt.Net;

namespace ATMSystem.Services.Implementations
{
    public class CardService(IUnitOfWork _unitOfWork) : ICardService
    {

        public async Task<Card> CreateCardAsync(CreateCardDto dto)
        {
            var account = await _unitOfWork.Accounts.GetByIdAsync(dto.AccountNumber);
            if (account == null)
                throw new Exception("Account not found");

            var card = new Card
            {
                CardNumber = dto.CardNumber.ToString(),
                ExpiryDate = DateTime.SpecifyKind(dto.ExpiryDate, DateTimeKind.Utc),
                PinHash = BCrypt.Net.BCrypt.HashPassword(dto.PinCode),
                AccountNumber = dto.AccountNumber
            };

            await _unitOfWork.Cards.AddAsync(card);
            await _unitOfWork.CompleteAsync();

            return card;
        }

        public async Task<bool> VerifyPinAsync(int cardId, string pinCode)
        {
            var card = await _unitOfWork.Cards.GetByIdAsync(cardId);
            if (card == null) return false;

            return BCrypt.Net.BCrypt.Verify(pinCode, card.PinHash);
        }

        public async Task<Card?> GetCardByIdAsync(int cardId)
        {
            return await _unitOfWork.Cards.GetByIdAsync(cardId);
        }

        public async Task<bool> DeleteCardAsync(int cardId)
        {
            var card = await _unitOfWork.Cards.GetByIdAsync(cardId);
            if (card == null) return false;

            await _unitOfWork.Cards.DeleteAsync(cardId);
            await _unitOfWork.CompleteAsync();
            return true;
        }


    }

}
