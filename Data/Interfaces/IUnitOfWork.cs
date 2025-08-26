using ATMSystem.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace ATMSystem.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Customers { get; }
        IAccountRepository Accounts { get; }   
        IRepository<Card> Cards { get; }
        IRepository<Transaction> Transactions { get; }
        IATMRepository ATMs { get; }           
        IRepository<TransactionType> TransactionTypes { get; }

        Task<int> CompleteAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();

        void Dispose();
    }

}
