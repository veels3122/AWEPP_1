using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;

namespace AWEPP.Services
{
    public class ContactsServices : IContactsServices
    {
        private readonly IContactsRepository _contactsRepository;

        public ContactsServices(IContactsRepository contactsRepository)
        {
            _contactsRepository = contactsRepository;
        }

        public async Task CreateContactsAsync(Contacts Contacts)
        {
            await _contactsRepository.CreateContactsAsync(Contacts);
        }

        public async Task<IEnumerable<Contacts>> GetAllContactsAsync()
        {
            return await _contactsRepository.GetAllContactsAsync();
        }

        public async Task<Contacts> GetContactsByIdAsync(int Id)
        {
            return await _contactsRepository.GetContactsByIdAsync(Id);
        }

        public async Task SoftDeleteContactsAsync(int Id)
        {
            await _contactsRepository.SoftDeleteContactsAsync(Id);
        }

        public async Task UpdateContactsAsync(Contacts Contacts)
        {
            await _contactsRepository.UpdateContactsAsync(Contacts);
        }
    }
}




