using AWEPP.Model;
using AWEPP.Modelo;

namespace AWEPP.Repositories
{
    public interface ITypeIdentyRepository
    {
        Task<IEnumerable<TypeIdenty>> GetAllTypeIdentyAsync();
        Task<TypeIdenty> GetTypeIdentyByIdAsync(int Id);
        Task CreateTypeIdentyAsync(TypeIdenty TypeIdentities);
        Task UpdateTypeIdentyAsync(TypeIdenty TypeIdentities);
        Task SoftDeleteTypeIdentyAsync(int Id);
    }
}
