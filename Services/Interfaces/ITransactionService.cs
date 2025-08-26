using ATMSystem.Models;

namespace ATMSystem.Services.Interfaces
{
    public interface ITransactionService
    {
        Task DepositAsync(int cardId, string pinCode, int atmId, decimal amount);
        Task WithdrawAsync(int cardId, string pinCode, int atmId, decimal amount);
    }
}
