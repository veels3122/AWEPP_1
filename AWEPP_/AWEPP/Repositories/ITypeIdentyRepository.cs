using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeIdentyRepository
    {
        Task<IEnumerable<TypeIdenty>> GetAllTypeIdentyAsync();
        Task<TypeIdenty> GetTypeIdentyByIdAsync(int id);
        Task<TypeIdenty> CreateTypeIdentyAsync(TypeIdenty typeIdenty);
        Task<TypeIdenty> UpdateTypeIdentyAsync(TypeIdenty typeIdenty);
        Task SoftDeleteTypeIdentyAsync(int id);
    }

}