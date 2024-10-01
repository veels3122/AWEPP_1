using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeAccesUserRepository
    {
        Task<IEnumerable<UserRepository>> GetAllTypeAccesUsersAsync();
        Task<UserRepository> GetTypeAccesUserByIdAsync(int id);
        Task<UserRepository> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task<UserRepository> UpdateTypeAccesUserAsync(TypeAccesUser typeAccesUser);
        Task SoftDeleteTypeAccesUserAsync(int id);
    }
    public class TypeAccesUserRepository : ITypeAccesUserRepository
    {
        public Task<UserRepository> CreateTypeAccesUserAsync(TypeAccesUser typeAccesUser)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserRepository>> GetAllTypeAccesUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserRepository> GetTypeAccesUserByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteTypeAccesUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserRepository> UpdateTypeAccesUserAsync(TypeAccesUser typeAccesUser)
        {
            throw new NotImplementedException();
        }
    }
}