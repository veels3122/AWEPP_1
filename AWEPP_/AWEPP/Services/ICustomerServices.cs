using AWEPP.Model;

namespace AWEPP.Services
{
    public interface ICustomerServices
    {
        Task<IEnumerable<Customer>> GetAllCustomerAsync();
        Task<Customer> GetCustomerByIdAsync(int Id);
        Task CreateCustomerAsync(Customer Customers);
        Task UpdateCustomerAsync(Customer Customers);
        Task SoftDeleteCustomerAsync(int Id);
    }
}
