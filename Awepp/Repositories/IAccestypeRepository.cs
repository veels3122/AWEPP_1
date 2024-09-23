using AWEPP.Model;
using System.Security.AccessControl;

namespace AWEPP.Repositories
{
    public interface IAccestypeRepository
    {
        Task<IEnumerable<TypeAcces>> GetAllAccestype_RepositoryAsync();
        Task<TypeAcces> GetAccestype_RepositoryByIdAsync(int Id);
        Task CreateAccestype_RepositoryAsync(TypeAcces accestype_repository);
        Task UpdateAccestype_RepositoryAsync(TypeAcces accestype_repository);
        Task SoftDeleteAccestype_RepositoryAsync(int Id);
    
    }

    public class AccestypeRepository : IAccestypeRepository
    {
        public Task CreateAccestype_RepositoryAsync(TypeAcces accestype_repository)
        {
            throw new NotImplementedException();
        }

        public Task<TypeAcces> GetAccestype_RepositoryByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TypeAcces>> GetAllAccestype_RepositoryAsync()
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteAccestype_RepositoryAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAccestype_RepositoryAsync(TypeAcces accestype_repository)
        {
            throw new NotImplementedException();
        }
    }

}
