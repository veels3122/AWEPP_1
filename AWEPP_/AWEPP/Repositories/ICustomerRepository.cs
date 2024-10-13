using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Security.AccessControl;

namespace AWEPP.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<Customer> CreateCustomerAsync(Customer customer);
        Task<Customer> UpdateCustomerAsync(Customer customer);
        Task SoftDeleteCustomerAsync(int id);
        Task<Customer> GetCustomerByNumIdentyAsync(int numIdenty);  // Search by NumIdenty
        Task<bool> ExistsCustomerByNumIdentyAsync(int numIdenty);


    }
}