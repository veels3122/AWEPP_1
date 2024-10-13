using AWEPP.Modelo;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{

    public class UsertypeServices : IUsertypeServices
    {
        private readonly IUsertypeRepository _usertypeRepository;

        public UsertypeServices(IUsertypeRepository usertypeRepository)
        {
            _usertypeRepository = usertypeRepository;
        }

        public async Task<IEnumerable<Usertype>> GetAllUsertypesAsync()
        {
            return await _usertypeRepository.GetAllUsertypesAsync();
        }

        public async Task<Usertype> GetUsertypeByIdAsync(int id)
        {
            return await _usertypeRepository.GetUsertypeByIdAsync(id);
        }

        public async Task<Usertype> CreateUsertypeAsync(Usertype usertype)
        {
            if (string.IsNullOrEmpty(usertype.Name))
            {
                throw new ArgumentException("El nombre del tipo de usuario es obligatorio.");
            }

            return await _usertypeRepository.CreateUsertypeAsync(usertype);
        }

        public async Task<Usertype> UpdateUsertypeAsync(Usertype usertype)
        {
            return await _usertypeRepository.UpdateUsertypeAsync(usertype);
        }

        public async Task SoftDeleteUsertypeAsync(int id)
        {
            await _usertypeRepository.SoftDeleteUsertypeAsync(id);
        }
    }
}