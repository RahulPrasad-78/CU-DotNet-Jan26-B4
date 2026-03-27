using Microsoft.AspNetCore.Mvc;
using AccountServices.Services;
using AccountServices.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace AccountServices.Controllers
{
    [ApiController]
    [Route("accounts")]
    [Authorize(Roles = "Admin")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(IAccountService service)
        {
            _service = service;
        }

        // Create Account
        [HttpPost]
        public async Task<IActionResult> CreateAccount(CreateAccountDto dto)
        {
            var result = await _service.CreateAccount(dto);
            return Ok(result);
        }

        // Get All
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAccounts();
            return Ok(result);
        }

        // Get By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetAccountById(id);
            return Ok(result);
        }

        // Deposit
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] TransactionDto dto)
        {
            var result = await _service.Deposit(dto);
            return Ok(result);
        }

        // Withdraw
        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw(TransactionDto dto)
        {
            var result = await _service.Withdraw(dto);
            return Ok(result);
        }
    }
}