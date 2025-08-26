using ATMSystem.Data.Interfaces;
using ATMSystem.Data.Repositories;
using ATMSystem.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace ATMSystem.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IRepository<Customer> Customers { get; }
        public IAccountRepository Accounts { get; }
        public IRepository<Card> Cards { get; }
        public IRepository<Transaction> Transactions { get; }
        public IATMRepository ATMs { get; }
        public IRepository<TransactionType> TransactionTypes { get; }

        public UnitOfWork(
            AppDbContext context,
            IRepository<Customer> customerRepository,
            IAccountRepository accountRepository,
            IRepository<Card> cardRepository,
            IRepository<Transaction> transactionRepository,
            IATMRepository atmRepository,
            IRepository<TransactionType> transactionTypeRepository
        )
        {
            _context = context;

            Customers = customerRepository;
            Accounts = accountRepository;
            Cards = cardRepository;
            Transactions = transactionRepository;
            ATMs = atmRepository;
            TransactionTypes = transactionTypeRepository;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
