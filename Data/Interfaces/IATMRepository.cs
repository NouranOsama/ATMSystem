using ATMSystem.Models;

namespace ATMSystem.Data.Interfaces
{
    public interface IATMRepository : IRepository<ATM>
    {
        Task<ATM?> GetATMWithTransactionsAsync(int atmId);
    }
}
