using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeAccesUserRepository
    {
        Task<IEnumerable<TypeAccesUser>> GetAllTypeAccesUsersAsync();
        Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int id);
        Task<TypeAccesUser> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task<TypeAccesUser> UpdateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task SoftDeleteTypeAccesUserAsync(int id);
    }
    public class TypeAccesUserRepository : ITypeAccesUserRepository
    {
        public Task<TypeAccesUser> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TypeAccesUser>> GetAllTypeAccesUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TypeAccesUser> GetTypeAccesUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteTypeAccesUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TypeAccesUser> UpdateTypeAccesUserAsync(TypeAccesUser typeAccesUser)
        {
            throw new NotImplementedException();
        }
    }
}