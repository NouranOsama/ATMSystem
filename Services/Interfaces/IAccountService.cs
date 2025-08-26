using ATMSystem.DTOs;
using ATMSystem.Models;

namespace ATMSystem.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Account> CreateAccountAsync(CreateAccountDto dto);
        Task<Account?> GetAccountByIdAsync(int accountNumber);
        Task<bool> DeleteAccountAsync(int accountNumber);
    }
}
