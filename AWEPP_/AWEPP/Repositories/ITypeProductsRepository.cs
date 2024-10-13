using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeProductsRepository
    {
        Task<IEnumerable<TypeProducts>> GetAllTypeProductsAsync();
        Task<TypeProducts> GetTypeProductsByIdAsync(int id);
        Task<TypeProducts> CreateTypeProductsAsync(TypeProducts typeProducts);
        Task<TypeProducts> UpdateTypeProductsAsync(TypeProducts typeProducts);
        Task SoftDeleteTypeProductsAsync(int id);
    }

}