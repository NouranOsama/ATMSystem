using ATMSystem.Models;
using ATMSystem.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATMSystem.Data.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context) { }

        public async Task<Account?> GetAccountWithCustomerAsync(int accountNumber)
        {
            return await _context.Accounts
                .FromSqlRaw("SELECT * FROM \"Accounts\" WHERE \"AccountNumber\" = {0} FOR UPDATE", accountNumber)
                .FirstOrDefaultAsync();
        }
    }
}
