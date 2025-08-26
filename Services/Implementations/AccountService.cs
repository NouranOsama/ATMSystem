using ATMSystem.Data.Interfaces;
using ATMSystem.DTOs;
using ATMSystem.Models;
using ATMSystem.Services.Interfaces;

namespace ATMSystem.Services.Implementations
{
    public class AccountService(IUnitOfWork _unitOfWork) : IAccountService
    {
       public async Task<Account> CreateAccountAsync(CreateAccountDto dto)
        {

            var customer = await _unitOfWork.Customers.GetByIdAsync(dto.CustomerId);
            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

            var account = new Account
            {
                AccountType = dto.AccountType,
                Balance = dto.InitialBalance,
                CustomerId = dto.CustomerId
            };

            await _unitOfWork.Accounts.AddAsync(account);

            await _unitOfWork.CompleteAsync();

            return account;
        }
        public async Task<Account?> GetAccountByIdAsync(int accountNumber)
        {
            return await _unitOfWork.Accounts.GetByIdAsync(accountNumber);
        }

        public async Task<bool> DeleteAccountAsync(int accountNumber)
        {
            var account = await _unitOfWork.Accounts.GetByIdAsync(accountNumber);
            if (account == null)
                return false;

            await _unitOfWork.Accounts.DeleteAsync(accountNumber);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}
