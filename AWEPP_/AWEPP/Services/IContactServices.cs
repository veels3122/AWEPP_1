using AWEPP.Model;
using AWEPP.Modelo;
using System.Threading.Tasks;
using AWEPP.Repositories;


namespace AWEPP.Services
{
    public interface IContactServices
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactByIdAsync(int id);
        Task<Contact> CreateContactAsync(Contact contacts);
        Task<Contact> UpdateContactAsync(Contact contacts);
        Task SoftDeleteContactAsync(int id);
    }
   public class ContactServices : IContactServices
    {
        private readonly IContactRepository _contactRepository;

        public ContactServices(IContactRepository contactRepository)

        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _contactRepository.GetAllContactsAsync();
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await _contactRepository.GetContactByIdAsync(id);
        }

        public async Task<Contact> CreateContactAsync(Contact contacts)
        {
            if (string.IsNullOrEmpty(contacts.Contacts))
            {
                throw new ArgumentException("El nombre del contacto es obligatorio.");
            }

            return await _contactRepository.CreateContactAsync(contacts);
        }

        public async Task<Contact> UpdateContactAsync(Contact contacts)
        {
            if (contacts.Id <= 0)
            {
                throw new ArgumentException("El ID del contacto es inválido.");
            }

            if (string.IsNullOrEmpty(contacts.Contacts))
            {
                throw new ArgumentException("El nombre del contacto es obligatorio.");
            }

            return await _contactRepository.UpdateContactAsync(contacts);
        }

        public async Task SoftDeleteContactAsync(int id)
        {
            await _contactRepository.SoftDeleteContactAsync(id);
        }

       
    }
}