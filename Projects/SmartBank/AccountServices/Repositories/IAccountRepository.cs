using System.Collections.Generic;
using System.Threading.Tasks;
using AccountServices.Models;

namespace AccountServices.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> Create(Account account);
        Task<List<Account>> GetAll();
        Task<Account?> GetById(int id);
        Task Update(Account account);
    }
}