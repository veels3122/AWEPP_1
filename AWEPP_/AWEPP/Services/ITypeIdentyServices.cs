using AWEPP.Model;

namespace AWEPP.Services
{
    public interface ITypeIdentyServices
    {
        Task<IEnumerable<TypeIdenty>> GetAllTypeIdentyAsync();
        Task<TypeIdenty> GetTypeIdentyByIdAsync(int Id);
        Task CreateTypeIdentyAsync(TypeIdenty TypeIdentities);
        Task UpdateTypeIdentyAsync(TypeIdenty TypeIdentities);
        Task SoftDeleteTypeIdentyAsync(int Id);
    }
}
