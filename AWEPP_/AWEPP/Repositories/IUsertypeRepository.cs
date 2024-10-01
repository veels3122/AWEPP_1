using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;

namespace AWEPP.Repositories
{
    public interface IUsertypeRepository
    {
        Task<IEnumerable<Usertype>> GetAllUserstypesAsync();
        Task<Usertype> GetUsertypesByIdAsync(int id);
        Task<Usertype> CreateUsertypesAsync(Usertype Usertypes);
        Task<Usertype> UpdateUsertypesAsync(Usertype Usertypes);
        Task SoftDeleteUsertypesAsync(int id);
    }
    public class UserTypeRepository : IUsertypeRepository
    {
        public Task<Usertype> CreateUsertypesAsync(Usertype Usertypes)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usertype>> GetAllUserstypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Usertype> GetUsertypesByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteUsertypesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usertype> UpdateUsertypesAsync(Usertype Usertypes)
        {
            throw new NotImplementedException();
        }
    }
}
