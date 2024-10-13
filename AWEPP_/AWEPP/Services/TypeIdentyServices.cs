using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    

    public class TypeIdentyServices : ITypeIdentyServices
    {
        private readonly ITypeIdentyRepository _typeIdentyRepository;

        public TypeIdentyServices(ITypeIdentyRepository typeIdentyRepository)
        {
            _typeIdentyRepository = typeIdentyRepository;
        }

        public async Task<IEnumerable<TypeIdenty>> GetAllTypeIdentyAsync()
        {
            return await _typeIdentyRepository.GetAllTypeIdentyAsync();
        }

        public async Task<TypeIdenty> GetTypeIdentyByIdAsync(int id)
        {
            return await _typeIdentyRepository.GetTypeIdentyByIdAsync(id);
        }

        public async Task<TypeIdenty> CreateTypeIdentyAsync(TypeIdenty typeIdenty)
        {
            if (string.IsNullOrEmpty(typeIdenty.TipoIdenty))
            {
                throw new ArgumentException("El nombre del tipo de identidad es obligatorio.");
            }

            return await _typeIdentyRepository.CreateTypeIdentyAsync(typeIdenty);
        }

        public async Task<TypeIdenty> UpdateTypeIdentyAsync(TypeIdenty typeIdenty)
        {
            return await _typeIdentyRepository.UpdateTypeIdentyAsync(typeIdenty);
        }

        public async Task SoftDeleteTypeIdentyAsync(int id)
        {
            await _typeIdentyRepository.SoftDeleteTypeIdentyAsync(id);
        }
    }
}