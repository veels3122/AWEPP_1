using AWEPP.Model;
using AWEPP.Modelo;
using System.Threading.Tasks;
using AWEPP.Repositories;


namespace AWEPP.Services
{
   
   public class ContactServices : IContactsServices
    {
        private readonly IContactsRepository _contactRepository;

        public ContactServices(IContactsRepository contactRepository)

        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contacts>> GetAllContactsAsync()
        {
            return await _contactRepository.GetAllContactsAsync();
        }

        public async Task<Contacts> GetContactByIdAsync(int id)
        {
            return await _contactRepository.GetContactByIdAsync(id);
        }

        public async Task<Contacts> CreateContactAsync(Contacts contacts)
        {
            if (string.IsNullOrEmpty(contacts.Contact))
            {
                throw new ArgumentException("El nombre del contacto es obligatorio.");
            }

            return await _contactRepository.CreateContactAsync(contacts);
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

            return await _contactRepository.UpdateContactAsync(contacts);
        }

        public async Task SoftDeleteContactAsync(int id)
        {
            await _contactRepository.SoftDeleteContactAsync(id);
        }

       
    }
}