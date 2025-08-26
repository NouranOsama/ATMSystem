using ATMSystem.DTO;

namespace ATMSystem.Services.Interfaces
{
    public interface IAtmService
    {
        Task<AtmResponseDto> CreateAsync(CreateAtmDto dto);
        Task<AtmResponseDto?> GetByIdAsync(int atmId);
        Task<IEnumerable<AtmResponseDto>> GetAllAsync();
        Task<AtmResponseDto?> UpdateAsync(int atmId, UpdateAtmDto dto);
        Task<bool> DeleteAsync(int atmId);
    }
}
