using ATMSystem.DTOs;
using ATMSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ATMSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController(ICardService _cardService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateCard(CreateCardDto dto)
        {
            try
            {
                var card = await _cardService.CreateCardAsync(dto);
                return Ok(card);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{cardId}")]
        public async Task<IActionResult> DeleteCard(int cardId)
        {
            var deleted = await _cardService.DeleteCardAsync(cardId);
            if (!deleted)
                return NotFound(new { Message = "Card not found" });

            return NoContent();
        }

    }
}