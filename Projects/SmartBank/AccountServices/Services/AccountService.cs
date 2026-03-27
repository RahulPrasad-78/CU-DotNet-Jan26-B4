using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountServices.DTOs;
using AccountServices.Exceptions;
using AccountServices.Helpers;
using AccountServices.Models;
using AccountServices.Repositories;

namespace AccountServices.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;

        public AccountService(IAccountRepository repo)
        {
            _repo = repo;
        }

        public async Task<AccountDto> CreateAccount(CreateAccountDto dto)
        {
            if (dto.InitialDeposit < 1000)
                throw new BadRequestException("Minimum deposit must be ₹1000");

            var account = new Account
            {
                Name = dto.Name,
                Balance = dto.InitialDeposit,
                CreatedAt = DateTime.Now
            };

            var saved = await _repo.Create(account);

            // Generate account number AFTER save
            saved.AccountNumber = AccountNumberGenerator.GenerateAccountNumber(saved.CreatedAt.Year, saved.Id);
            await _repo.Update(saved);

            return MapToDto(saved);
        }

        public async Task<List<AccountDto>> GetAllAccounts()
        {
            var accounts = await _repo.GetAll();
            return accounts.ConvertAll(a => MapToDto(a));
        }

        public async Task<AccountDto> GetAccountById(int id)
        {
            var account = await _repo.GetById(id);

            if (account == null)
                throw new NotFoundException("Account not found");

            return MapToDto(account);
        }

        public async Task<AccountDto> Deposit(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            var account = await _repo.GetById(dto.AccountId);

            if (account == null)
                throw new NotFoundException("Account not found");

            account.Balance += dto.Amount;
            await _repo.Update(account);

            return MapToDto(account);
        }

        public async Task<AccountDto> Withdraw(TransactionDto dto)
        {
            if (dto.Amount <= 0)
                throw new BadRequestException("Amount must be greater than 0");

            var account = await _repo.GetById(dto.AccountId);

            if (account == null)
                throw new NotFoundException("Account not found");

            if (account.Balance - dto.Amount < 1000)
                throw new BadRequestException("Minimum balance must be ₹1000");

            account.Balance -= dto.Amount;
            await _repo.Update(account);

            return MapToDto(account);
        }

        private AccountDto MapToDto(Account acc)
        {
            return new AccountDto
            {
                Id = acc.Id,
                AccountNumber = acc.AccountNumber,
                Name = acc.Name,
                Balance = acc.Balance
            };
        }
    }
}