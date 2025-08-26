using ATMSystem.Data.Interfaces;
using ATMSystem.Models;
using ATMSystem.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace ATMSystem.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardService _cardService;
        private readonly ILogger<TransactionService> _logger;

        public TransactionService(IUnitOfWork unitOfWork, ICardService cardService, ILogger<TransactionService> logger)
        {
            _unitOfWork = unitOfWork;
            _cardService = cardService;
            _logger = logger;
        }

        public async Task DepositAsync(int cardId, string pinCode, int atmId, decimal amount)
        {
            _logger.LogInformation("Deposit started: CardId={CardId}, ATM={AtmId}, Amount={Amount}", cardId, atmId, amount);

            var card = await _unitOfWork.Cards.GetByIdAsync(cardId);
            if (card == null)
            {
                _logger.LogWarning("Deposit failed: Card {CardId} not found", cardId);
                throw new Exception("Card not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(pinCode, card.PinHash))
            {
                _logger.LogWarning("Deposit failed: Invalid PIN for Card {CardId}", cardId);
                throw new Exception("Invalid PIN");
            }

            var account = await _unitOfWork.Accounts.GetByIdAsync(card.AccountNumber);
            if (account == null) throw new Exception("Account not found");

            var atm = await _unitOfWork.ATMs.GetByIdAsync(atmId);
            if (atm == null) throw new Exception("ATM not found");

            account.Balance += amount;
            atm.CashAvailable += amount;

            await _unitOfWork.Accounts.UpdateAsync(account);
            await _unitOfWork.ATMs.UpdateAsync(atm);

            var transaction = new Transaction
            {
                AccountNumber = account.AccountNumber,
                AtmId = atmId,
                Amount = amount,
                TransactionDateTime = DateTime.UtcNow,
                TransactionType = await _unitOfWork.TransactionTypes.GetByIdAsync(1) 
            };

            await _unitOfWork.Transactions.AddAsync(transaction);
            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("Deposit successful: Account={Account}, NewBalance={Balance}, ATM={AtmId}, NewCash={Cash}",
                account.AccountNumber, account.Balance, atmId, atm.CashAvailable);
        }

        public async Task WithdrawAsync(int cardId, string pinCode, int atmId, decimal amount)
        {
            _logger.LogInformation("Withdrawal started: CardId={CardId}, ATM={AtmId}, Amount={Amount}", cardId, atmId, amount);

            var card = await _unitOfWork.Cards.GetByIdAsync(cardId);
            if (card == null)
            {
                _logger.LogWarning("Withdrawal failed: Card {CardId} not found", cardId);
                throw new Exception("Card not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(pinCode, card.PinHash))
            {
                _logger.LogWarning("Withdrawal failed: Invalid PIN for Card {CardId}", cardId);
                throw new Exception("Invalid PIN");
            }

            var account = await _unitOfWork.Accounts.GetByIdAsync(card.AccountNumber);
            if (account == null) throw new Exception("Account not found");
            if (account.Balance < amount)
            {
                _logger.LogWarning("Withdrawal failed: Insufficient funds on Account {AccountNumber}", account.AccountNumber);
                throw new Exception("Insufficient funds");
            }

            var atm = await _unitOfWork.ATMs.GetByIdAsync(atmId);
            if (atm == null) throw new Exception("ATM not found");
            if (atm.CashAvailable < amount)
            {
                _logger.LogWarning("Withdrawal failed: ATM {AtmId} has insufficient cash", atmId);
                throw new Exception("ATM has insufficient cash");
            }

            account.Balance -= amount;
            atm.CashAvailable -= amount;

            await _unitOfWork.Accounts.UpdateAsync(account);
            await _unitOfWork.ATMs.UpdateAsync(atm);

            var transaction = new Transaction
            {
                AccountNumber = account.AccountNumber,
                AtmId = atmId,
                Amount = amount,
                TransactionDateTime = DateTime.UtcNow,
                TransactionType = await _unitOfWork.TransactionTypes.GetByIdAsync(2) 
            };

            await _unitOfWork.Transactions.AddAsync(transaction);
            await _unitOfWork.CompleteAsync();

            _logger.LogInformation("Withdrawal successful: Account={Account}, NewBalance={Balance}, ATM={AtmId}, NewCash={Cash}",
                account.AccountNumber, account.Balance, atmId, atm.CashAvailable);
        }
    }
}
    