using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeAccesRepository
    {
        Task<IEnumerable<TypeAcces>> GetAllTypeAccesAsync();
        Task<TypeAcces> GetTypeAccesByIdAsync(int id);
        Task<TypeAcces> CreateTypeAccesAsync(TypeAcces typeAcces);
        Task<TypeAcces> UpdateTypeAccesAsync(TypeAcces typeAcces);
        Task SoftDeleteTypeAccesAsync(int id);
    }

}