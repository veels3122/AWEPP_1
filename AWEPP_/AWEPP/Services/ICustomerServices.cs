using AWEPP.Model;
using AWEPP.Modelo;
using System.Threading.Tasks;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    public interface ICustomerServices
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task SoftDeleteCustomerAsync(int id);

    }
    public class CustomerService : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)

        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _customerRepository.GetAllCustomersAsync();

        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await _customerRepository.GetCustomerByIdAsync(id);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            if (await _customerRepository.ExistsCustomerByNumIdentyAsync(customer.NumIdenty))
            {
                throw new ArgumentException("Ya existe un cliente con ese número de identificación.");
            }

            return await _customerRepository.CreateCustomerAsync(customer);
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = await _customerRepository.GetCustomerByIdAsync(customer.Id);
            if (existingCustomer == null)
            {
                throw new ArgumentException("No se encontró el cliente.");
            }
            return await _customerRepository.UpdateCustomerAsync(customer);
        }

        public async Task SoftDeleteCustomerAsync(int id)
        {
            await _customerRepository.SoftDeleteCustomerAsync(id);
        }

    }
}