using AWEPP.Model;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomersRepository _customerRepository;

        public CustomerServices(ICustomersRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task CreateCustomerAsync(Customer Customers)
        {
            await _customerRepository.CreateCustomerAsync(Customers);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            return await _customerRepository.GetAllCustomerAsync();
        }

       
        public async Task<Customer> GetCustomerByIdAsync(int Id)
        {
            return await _customerRepository.GetCustomerByIdAsync(Id);
        }

        public async Task SoftDeleteCustomerAsync(int Id)
        {
            await _customerRepository.SoftDeleteCustomerAsync(Id);
        }

        public async Task UpdateCustomerAsync(Customer Customers)
        {
            await _customerRepository.UpdateCustomerAsync(Customers);
        }
    }
}
