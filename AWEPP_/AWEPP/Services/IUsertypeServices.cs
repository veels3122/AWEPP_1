using AWEPP.Modelo;

namespace AWEPP.Services
{
    public interface IUsertypeServices
    {
        Task<IEnumerable<Usertype>> GetAllUsertypeAsync();
        Task<Usertype> GetUsertypeByIdAsync(int Id);
        Task CreateUsertypeAsync(Usertype UserTypes);
        Task UpdateUsertypeAsync(Usertype UserTypes);
        Task SoftDeleteUsertypeAsync(int Id);
    }
}
