using ATMSystem.DTOs;
using ATMSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ATMSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController(IAccountService _accountService) : ControllerBase
    {

        [HttpPost("create")]
        public async Task<IActionResult> CreateAccount(CreateAccountDto dto)
        {
            try
            {
                var account = await _accountService.CreateAccountAsync(dto);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{accountNumber}")]
        public async Task<IActionResult> DeleteAccount(int accountNumber)
        {
            var deleted = await _accountService.DeleteAccountAsync(accountNumber);
            if (!deleted)
                return NotFound(new { Message = "Account not found" });

            return NoContent();
        }
    }
}
