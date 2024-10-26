using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class CustomerRepository : IContactsRepository
    {
        private readonly Aweppcontext _context;

        public CustomerRepository(Aweppcontext context)
        {
            _context = context;
        }

        // Método para crear un nuevo gasto
        public async Task CreateContactsAsync(Contacts Contacts)
        {
            await _context.Contacts.AddAsync(Contacts); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }

        // Obtener todos los gastos que no están eliminados
        public async Task<IEnumerable<Contacts>> GetAllContactsAsync()
        {
            return await _context.Contacts
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }
        // Obtener gasto por su Id, excluyendo eliminados
        public async Task<Contacts> GetContactsByIdAsync(int Id)
        {
            return await _context.Contacts
                .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }
        // Eliminar gasto de manera lógica (Soft Delete)
        public async Task SoftDeleteContactsAsync(int Id)
        {
            var Contacts = await _context.Contacts.FindAsync(Id);
            if (Contacts != null)
            {
                Contacts.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }

      

        // Actualizar un gasto existente
        public async Task UpdateContactsAsync(Contacts Contacts)
        {
            var existingContacts = await _context.Contacts.FindAsync(Contacts.Id);
            if (existingContacts != null)
            {
                // Actualizar campos
                existingContacts.Contact = Contacts.Contact;
                existingContacts.IsDeleted = Contacts.IsDeleted;


                // Guardar cambios
                await _context.SaveChangesAsync();
            }
        }
    }
}









