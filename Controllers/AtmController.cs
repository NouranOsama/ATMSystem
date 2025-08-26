using ATMSystem.DTO;
using ATMSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ATMSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtmsController(IAtmService _atmService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAtmDto dto)
        {
            try
            {
                var result = await _atmService.CreateAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _atmService.GetByIdAsync(id);
            return result is null ? NotFound() : Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _atmService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAtmDto dto)
        {
            try
            {
                var result = await _atmService.UpdateAsync(id, dto);
                return result is null ? NotFound() : Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _atmService.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
