using AWEPP.Modelo;

namespace AWEPP.Controllers
{
    public interface IUsertypeControllers
    {
        public interface IUsertypeControllers
        {
            Task<IEnumerable<Usertype>> GetAllUserstypesAsync();
            Task<Usertype> GetUsertypesByIdAsync(int id);
            Task<Usertype> CreateUsertypesAsync(Usertype Usertypes);
            Task<Usertype> UpdateUsertypesAsync(Usertype Usertypes);
            Task SoftDeleteUsertypesAsync(int id);
        }
        public class UserTypeControllers : IUsertypeControllers
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
}
