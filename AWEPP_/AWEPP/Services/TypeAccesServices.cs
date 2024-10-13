using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    
    public class TypeAccesServices : ITypeAccesServices
    {
        private readonly ITypeAccesRepository _typeAccesRepository;

        public TypeAccesServices(ITypeAccesRepository typeAccesRepository)
        {
            _typeAccesRepository = typeAccesRepository;
        }

        public async Task<IEnumerable<TypeAcces>> GetAllTypeAccesAsync()
        {
            return await _typeAccesRepository.GetAllTypeAccesAsync();
        }

        public async Task<TypeAcces> GetTypeAccesByIdAsync(int id)
        {
            return await _typeAccesRepository.GetTypeAccesByIdAsync(id);
        }

        public async Task<TypeAcces> CreateTypeAccesAsync(TypeAcces typeAcces)
        {
            if (string.IsNullOrEmpty(typeAcces.Typeacces))
            {
                throw new ArgumentException("El nombre del tipo de acceso es obligatorio.");
            }

            return await _typeAccesRepository.CreateTypeAccesAsync(typeAcces);
        }

        public async Task<TypeAcces> UpdateTypeAccesAsync(TypeAcces typeAcces)
        {
            return await _typeAccesRepository.UpdateTypeAccesAsync(typeAcces);
        }

        public async Task SoftDeleteTypeAccesAsync(int id)
        {
            await _typeAccesRepository.SoftDeleteTypeAccesAsync(id);
        }
    }
}