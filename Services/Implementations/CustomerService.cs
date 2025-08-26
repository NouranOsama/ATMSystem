using ATMSystem.Data.Interfaces;
using ATMSystem.DTOs.Customer;
using ATMSystem.Services.Interfaces;
using ATMSystem.Models;
using System.Threading.Tasks;

namespace ATMSystem.Services.Implementations
{
    public class CustomerService(IUnitOfWork _unitOfWork) : ICustomerService
    {
      public async Task<int> CreateCustomerAsync(CustomerCreateDto dto)
        {
            var customer = new Customer
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };

            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.CompleteAsync();

            return customer.CustomerId; 
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _unitOfWork.Customers.GetByIdAsync(id);
        }
    }
}
