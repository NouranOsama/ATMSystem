using ATMSystem.DTOs.Customer;
using ATMSystem.Models;
using System.Threading.Tasks;

namespace ATMSystem.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<int> CreateCustomerAsync(CustomerCreateDto dto);
        Task<Customer> GetCustomerByIdAsync(int id);
    }
}
