using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using System.Threading.Tasks;
namespace AWEPP.Repositories
{
 

    public class ContactsRepository : IContactsRepository
    {
        private readonly Aweppcontext _context;

        public ContactsRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contacts>> GetAllContactsAsync()
        {
            return await _context.Contacts
                .ToListAsync();
        }

        public async Task<Contacts> GetContactByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Contacts
                .FirstOrDefaultAsync(c => c.Id == id );
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Contacts> UpdateContactAsync(Contacts contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contacts>CreateContactAsync(Contacts contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task SoftDeleteContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}
