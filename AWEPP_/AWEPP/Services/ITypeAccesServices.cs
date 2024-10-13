using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface ITypeAccesServices
    {
        Task<IEnumerable<TypeAcces>> GetAllTypeAccesAsync();
        Task<TypeAcces> GetTypeAccesByIdAsync(int id);
        Task<TypeAcces> CreateTypeAccesAsync(TypeAcces typeAcces);
        Task<TypeAcces> UpdateTypeAccesAsync(TypeAcces typeAcces);
        Task SoftDeleteTypeAccesAsync(int id);
    }

}