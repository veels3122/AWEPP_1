using AWEPP.Model;
using AWEPP.Modelo;

namespace AWEPP.Repositories
{
    public interface IContactsRepository

    {
        Task<IEnumerable<Contacts>> GetAllContactsAsync();
        Task<Contacts> GetContactsByIdAsync(int Id);
        Task CreateContactsAsync(Contacts Contacts);
        Task UpdateContactsAsync(Contacts Contacts);
        Task SoftDeleteContactsAsync(int Id);
    }
}
