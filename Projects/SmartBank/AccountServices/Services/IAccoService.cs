using System.Collections.Generic;
using System.Threading.Tasks;
using AccountServices.DTOs;

namespace AccountServices.Services
{
    public interface IAccountService
    {
        Task<AccountDto> CreateAccount(CreateAccountDto dto);
        Task<List<AccountDto>> GetAllAccounts();
        Task<AccountDto> GetAccountById(int id);
        Task<AccountDto> Deposit(TransactionDto dto);
        Task<AccountDto> Withdraw(TransactionDto dto);
    }
}