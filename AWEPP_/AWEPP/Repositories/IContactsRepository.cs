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
        Task<Contacts> CreateContactAsync(Contacts contact);
        Task<Contacts> UpdateContactAsync(Contacts contact);
        Task SoftDeleteContactAsync(int id);

        

    }

}
