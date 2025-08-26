using ATMSystem.Data.Interfaces;
using ATMSystem.DTO;
using ATMSystem.Models;
using ATMSystem.Services.Interfaces;

namespace ATMSystem.Services.Implementations
{
    public class AtmService(IUnitOfWork _uow) : IAtmService
    {
        public async Task<AtmResponseDto> CreateAsync(CreateAtmDto dto)
        {
            if (dto.InitialCash < 0)
                throw new ArgumentException("Initial cash must be >= 0");
            if (string.IsNullOrWhiteSpace(dto.Location))
                throw new ArgumentException("Location is required");

            var atm = new ATM
            {
                Location = dto.Location.Trim(),
                CashAvailable = dto.InitialCash,
                Status = dto.Status
            };

            await _uow.ATMs.AddAsync(atm);
            await _uow.CompleteAsync();

            return Map(atm);
        }

        public async Task<AtmResponseDto?> GetByIdAsync(int atmId)
        {
            var atm = await _uow.ATMs.GetByIdAsync(atmId);
            return atm is null ? null : Map(atm);
        }

        public async Task<IEnumerable<AtmResponseDto>> GetAllAsync()
        {
            var atms = await _uow.ATMs.GetAllAsync();
            return atms.Select(Map).ToList();
        }

        public async Task<AtmResponseDto?> UpdateAsync(int atmId, UpdateAtmDto dto)
        {
            var atm = await _uow.ATMs.GetByIdAsync(atmId);
            if (atm is null) return null;

            if (dto.Location is not null) atm.Location = dto.Location.Trim();
            if (dto.CashAvailable is not null)
            {
                if (dto.CashAvailable < 0)
                    throw new ArgumentException("CashAvailable must be >= 0");
                atm.CashAvailable = dto.CashAvailable.Value;
            }
            if (dto.Status is not null) atm.Status = dto.Status;

            await _uow.ATMs.UpdateAsync(atm);
            await _uow.CompleteAsync();

            return Map(atm);
        }

        public async Task<bool> DeleteAsync(int atmId)
        {
            var atm = await _uow.ATMs.GetByIdAsync(atmId);
            if (atm is null) return false;

            await _uow.ATMs.DeleteAsync(atmId);
            await _uow.CompleteAsync();
            return true;
        }

        private static AtmResponseDto Map(ATM atm) => new()
        {
            AtmId = atm.AtmId,
            Location = atm.Location,
            CashAvailable = atm.CashAvailable,
            Status = atm.Status
        };
    }
}
