using AWEPP.Model;
using AWEPP.Modelo;

namespace AWEPP.Services
{
    public interface IContactsServices
    {
        Task<IEnumerable<Contacts>> GetAllContactsAsync();
        Task<Contacts> GetContactsByIdAsync(int Id);
        Task CreateContactsAsync(Contacts Contacts);
        Task UpdateContactsAsync(Contacts Contacts);
        Task SoftDeleteContactsAsync(int Id);
    }
}
