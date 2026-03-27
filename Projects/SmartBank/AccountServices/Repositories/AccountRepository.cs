using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AccountServices.Models;
using AccountServices.Data;

namespace AccountServices.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AccountServicesContext _context;

        public AccountRepository(AccountServicesContext context)
        {
            _context = context;
        }

        public async Task<Account> Create(Account account)
        {
            _context.Account.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<List<Account>> GetAll()
        {
            return await _context.Account
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Account?> GetById(int id)
        {
            return await _context.Account.FindAsync(id);
        }

        public async Task Update(Account account)
        {
            _context.Account.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}