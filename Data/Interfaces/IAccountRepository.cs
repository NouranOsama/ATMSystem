using ATMSystem.Models;

namespace ATMSystem.Data.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account?> GetAccountWithCustomerAsync(int accountNumber);
    }
}
