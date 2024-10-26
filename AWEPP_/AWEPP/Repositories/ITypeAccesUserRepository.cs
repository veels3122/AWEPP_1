using AWEPP.Model;

namespace AWEPP.Repositories
{
    public interface ITypeAccesUserRepository
    {
        Task<IEnumerable<TypeAccesUser>> GetAllTypeAccesUserAsync();
        Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int Id);
        Task CreateTypeAccesUserAsync(TypeAccesUser TypeAccessUsers);
        Task UpdateTypeAccesUserAsync(TypeAccesUser TypeAccessUsers);
        Task SoftDeleteTypeAccesUserAsync(int Id);
    }
}
