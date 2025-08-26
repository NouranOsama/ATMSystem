using ATMSystem.Models;
using ATMSystem.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ATMSystem.Data.Repositories
{
    public class ATMRepository : Repository<ATM>, IATMRepository
    {
        public ATMRepository(AppDbContext context) : base(context) { }

        public async Task<ATM?> GetATMWithTransactionsAsync(int atmId)
        {
            return await _context.ATMs
                .FromSqlRaw("SELECT * FROM \"ATMs\" WHERE \"Id\" = {0} FOR UPDATE", atmId)
                .FirstOrDefaultAsync();
        }
    }
}
