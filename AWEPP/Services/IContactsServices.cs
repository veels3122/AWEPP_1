using AWEPP.Model;
using AWEPP.Modelo;
using System.Threading.Tasks;
using AWEPP.Repositories;


namespace AWEPP.Services
{
    public interface IContactsServices
    {
        Task<IEnumerable<Contacts>> GetAllContactsAsync();
        Task<Contacts> GetContactByIdAsync(int id);
        Task<Contacts> CreateContactAsync(Contacts contacts);
        Task<Contacts> UpdateContactAsync(Contacts contacts);
        Task SoftDeleteContactAsync(int id);
    }
   public class ContactsServices : IContactsServices
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsServices(IContactsRepository contactsRepository)

        {
            _contactsRepository = contactsRepository;
        }

        public async Task<IEnumerable<Contacts>> GetAllContactsAsync()
        {
            return await _contactsRepository.GetAllContactsAsync();
        }

        public async Task<Contacts> GetContactByIdAsync(int id)
        {
            return await _contactsRepository.GetContactByIdAsync(id);
        }

        public async Task<Contacts> CreateContactAsync(Contacts contacts)
        {
            if (string.IsNullOrEmpty(contacts.Contact))
            {
                throw new ArgumentException("El nombre del contacto es obligatorio.");
            }

            return await _contactsRepository.CreateContactAsync(contacts);
        }

        public async Task<Contacts> UpdateContactAsync(Contacts contacts)
        {
            if (contacts.Id <= 0)
            {
                throw new ArgumentException("El ID del contacto es inválido.");
            }

            if (string.IsNullOrEmpty(contacts.Contact))
            {
                throw new ArgumentException("El nombre del contacto es obligatorio.");
            }

            return await _contactsRepository.UpdateContactAsync(contacts);
        }

        public async Task SoftDeleteContactAsync(int id)
        {
            await _contactsRepository.SoftDeleteContactAsync(id);
        }

       
    }
}