using AWEPP.Modelo;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface IUsertypeServices
    {
        Task<IEnumerable<Usertype>> GetAllUsertypesAsync();
        Task<Usertype> GetUsertypeByIdAsync(int id);
        Task<Usertype> CreateUsertypeAsync(Usertype usertype);
        Task<Usertype> UpdateUsertypeAsync(Usertype usertype);
        Task SoftDeleteUsertypeAsync(int id);
    }
}