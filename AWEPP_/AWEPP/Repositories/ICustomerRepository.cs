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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Aweppcontext _context;

        public CustomerRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id );
#pragma warning restore CS8603 // Possible null reference return.
        }

        

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            // Encuentra el cliente existente en el contexto
            var existingCustomer = await _context.Customers.FindAsync(customer.Id);

            if (existingCustomer == null)
            {
                throw new NotFoundException("Cliente no encontrado");
            }

            // Copia las propiedades actualizadas al cliente existente
            existingCustomer.Name = customer.Name;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Adress = customer.Adress;
            existingCustomer.NumIdenty = customer.NumIdenty;
            existingCustomer.Contact = customer.Contact;
            existingCustomer.CitiesId = customer.CitiesId;
            // ... copia otras propiedades según sea necesario

            // Marca el cliente como modificado
            _context.Entry(existingCustomer).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return existingCustomer;
        }

            public async Task SoftDeleteCustomerAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Customer> GetCustomerByNumIdentyAsync(int numIdenty)
        {
#pragma warning disable CS8603 //posible null return
            return await _context.Customers
                .FirstOrDefaultAsync(c => c.NumIdenty == numIdenty );
        }
#pragma warning disable CS8603 //posible null return

        public async Task<bool> ExistsCustomerByNumIdentyAsync(int numIdenty)
        {
            return await _context.Customers.AnyAsync(c => c.NumIdenty == numIdenty);
        }

    }
}