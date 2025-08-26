using ATMSystem.DTOs;
using ATMSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ATMSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController(ITransactionService _transactionService) : ControllerBase
    {
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] TransactionRequestDto dto)
        {
            try
            {
                await _transactionService.DepositAsync(dto.CardId, dto.PinCode, dto.AtmId, dto.Amount);

                return Ok(new { Message = "Deposit successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] TransactionRequestDto dto)
        {
            try
            {
                await _transactionService.WithdrawAsync(dto.CardId, dto.PinCode, dto.AtmId, dto.Amount);

                return Ok(new { Message = "Withdrawal successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
