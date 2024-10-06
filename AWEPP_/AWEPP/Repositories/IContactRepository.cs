using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;
using System.Threading.Tasks;
namespace AWEPP.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task<Contact> CreateContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task SoftDeleteContactAsync(int id);

        

    }

    public class ContactRepository : IContactRepository
    {
        private readonly Aweppcontext _context;

        public ContactRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _context.Contacts
                .ToListAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _context.Contacts
                .FirstOrDefaultAsync(c => c.Id == id );
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<Contact> UpdateContactAsync(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact>CreateContactAsync(Contact contact)
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
