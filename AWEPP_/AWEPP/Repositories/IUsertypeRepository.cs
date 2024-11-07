using AWEPP.Model;
using AWEPP.Modelo;

namespace AWEPP.Repositories
{
    public interface IUserTypeRepository
    {
        Task<IEnumerable<Usertype>> GetAllUsertypeAsync();
        Task<Usertype> GetUsertypeByIdAsync(int Id);
        Task CreateUsertypeAsync(Usertype UserTypes);
        Task UpdateUsertypeAsync(Usertype UserTypes);
        Task SoftDeleteUsertypeAsync(int Id);
    }
}
