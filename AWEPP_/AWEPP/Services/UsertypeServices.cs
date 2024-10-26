using AWEPP.Modelo;
using AWEPP.Repositories;
using AWEPP.Services;

namespace AWEPP.Services
{
    public class UserTypeServices : IUsertypeServices
    {
        private readonly IUserTypeRepository _userTypeRepository;
        public UserTypeServices(IUserTypeRepository userTypeRepository)
        {
            _userTypeRepository = userTypeRepository;
        }
        public async Task CreateUsertypeAsync(Usertype UserTypes)
        {
            await _userTypeRepository.CreateUsertypeAsync(UserTypes);
        }

        public async Task<IEnumerable<Usertype>> GetAllUsertypeAsync()
        {
            return await _userTypeRepository.GetAllUsertypeAsync();
        }

        public async Task<Usertype> GetUsertypeByIdAsync(int Id)
        {
            return await _userTypeRepository.GetUsertypeByIdAsync(Id);
        }

        public async Task SoftDeleteUsertypeAsync(int Id)
        {
            await _userTypeRepository.SoftDeleteUsertypeAsync(Id);
        }

        public async Task UpdateUsertypeAsync(Usertype UserTypes)
        {
            await _userTypeRepository.UpdateUsertypeAsync(UserTypes);
        }
    }
}
