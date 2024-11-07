using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly Aweppcontext _context;

        public CustomersRepository(Aweppcontext context)
        {
            _context = context;
        }

        // Método para crear un nuevo gasto
        public async Task CreateCustomerAsync(Customer Customers)
        {
            await _context.Customers.AddAsync(Customers); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }

        // Obtener todos los gastos que no están eliminados
        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            return await _context.Customers
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }
        // Obtener gasto por su Id, excluyendo eliminados
        public async Task<Customer> GetCustomerByIdAsync(int Id)
        {
            return await _context.Customers
                .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }
        // Eliminar gasto de manera lógica (Soft Delete)
        public async Task SoftDeleteCustomerAsync(int Id)
        {
            var Customer = await _context.Customers.FindAsync(Id);
            if (Customer != null)
            {
                Customer.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }
        // Actualizar un gasto existente
        public async Task UpdateCustomerAsync(Customer Customers)
        {
            var existingCustomer = await _context.Customers.FindAsync(Customers.Id);
            if (existingCustomer != null)
            {
                // Actualizar campos
                existingCustomer.NumIdenty = Customers.NumIdenty;
                existingCustomer.Name = Customers.Name;
                existingCustomer.LastName = Customers.LastName;
                existingCustomer.Adress = Customers.Adress;
                existingCustomer.Contact = Customers.Contact;
                existingCustomer.User = Customers.User;
                existingCustomer.TypeIdenty = Customers.TypeIdenty;
                existingCustomer.Contacts = Customers.Contacts;
                existingCustomer.Cities = Customers.Cities;
                existingCustomer.IsDeleted = Customers.IsDeleted;


                // Guardar cambios
                await _context.SaveChangesAsync();
            }
        }
    }
}












