using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface ITypeIdentyServices
    {
        Task<IEnumerable<TypeIdenty>> GetAllTypeIdentyAsync();
        Task<TypeIdenty> GetTypeIdentyByIdAsync(int id);
        Task<TypeIdenty> CreateTypeIdentyAsync(TypeIdenty typeIdenty);
        Task<TypeIdenty> UpdateTypeIdentyAsync(TypeIdenty typeIdenty);
        Task SoftDeleteTypeIdentyAsync(int id);
    }

}