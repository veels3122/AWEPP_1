using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using System.Threading.Tasks;
namespace AWEPP.Repositories
{
    public interface IContactsRepository
    {
        Task<IEnumerable<Contacts>> GetAllContactsAsync();
        Task<Contacts> GetContactByIdAsync(int id);
        Task<Contacts> CreateContactAsync(Contacts contacts);
        Task<Contacts> UpdateContactAsync(Contacts contacts);
        Task SoftDeleteContactAsync(int id);

        

    }

    public class ContactsRepository : IContactsRepository
    {
        private readonly Aweppcontext _context;

        public ContactsRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contacts>> GetAllContactsAsync()
        {
            return await _context.Contact
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<Contacts> GetContactByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Contact
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Contacts> UpdateContactAsync(Contacts contacts)
        {
            _context.Entry(contacts).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return contacts;
        }

        public async Task<Contacts>CreateContactAsync(Contacts contacts)
        {
            _context.Contact.Add(contacts);
            await _context.SaveChangesAsync();
            return contacts;
        }

        public async Task SoftDeleteContactAsync(int id)
        {
            var contact = await _context.Contact.FindAsync(id);
            if (contact != null)
            {
                contact.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
