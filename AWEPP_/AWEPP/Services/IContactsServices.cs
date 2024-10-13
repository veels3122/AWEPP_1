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
}