using AWEPP.Model;
using AWEPP.Repositories;
using System.Threading.Tasks;

namespace AWEPP.Services
{
    public interface ITypeProductsServices
    {
        Task<IEnumerable<TypeProducts>> GetAllTypeProductsAsync();
        Task<TypeProducts> GetTypeProductsByIdAsync(int id);
        Task<TypeProducts> CreateTypeProductsAsync(TypeProducts typeProducts);
        Task<TypeProducts> UpdateTypeProductsAsync(TypeProducts typeProducts);
        Task SoftDeleteTypeProductsAsync(int id);
    }

}