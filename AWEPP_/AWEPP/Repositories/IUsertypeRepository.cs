using AWEPP.Context;
using AWEPP.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface IUsertypeRepository
    {
        Task<IEnumerable<Usertype>> GetAllUsertypesAsync();
        Task<Usertype> GetUsertypeByIdAsync(int id);
        Task<Usertype> CreateUsertypeAsync(Usertype usertype);
        Task<Usertype> UpdateUsertypeAsync(Usertype usertype);
        Task SoftDeleteUsertypeAsync(int id);
    }

}