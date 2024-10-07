using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
    public interface ITypeAccountRepository
    {
        Task<IEnumerable<TypeAccount>> GetAllTypeAccountsAsync();
        Task<TypeAccount> GetTypeAccountByIdAsync(int id);
        Task<TypeAccount> CreateTypeAccountAsync(TypeAccount typeAccount);
        Task<TypeAccount> UpdateTypeAccountAsync(TypeAccount typeAccount);
        Task SoftDeleteTypeAccountAsync(int id);
    }

    public class TypeAccountRepository : ITypeAccountRepository
    {
        private readonly Aweppcontext _context;

        public TypeAccountRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeAccount>> GetAllTypeAccountsAsync()
        {
            return await _context.TypeAccounts
                .ToListAsync();
        }

        public async Task<TypeAccount> GetTypeAccountByIdAsync(int id)
        {
#pragma warning disable CS8603
            return await _context.TypeAccounts
                .FirstOrDefaultAsync(c => c.Id == id);
#pragma warning disable CS8603
        }

        public async Task<TypeAccount> CreateTypeAccountAsync(TypeAccount typeAccount)
        {
            _context.TypeAccounts.Add(typeAccount);
            await _context.SaveChangesAsync();
            return typeAccount;
        }

        public async Task<TypeAccount> UpdateTypeAccountAsync(TypeAccount typeAccount)
        {
            var existingTypeAccount = await _context.TypeAccounts.FindAsync(typeAccount.Id);

            if (existingTypeAccount == null)
            {
                throw new NotFoundException("TypeAccount not found");
            }

            existingTypeAccount.TypeAccounts = typeAccount.TypeAccounts;
            existingTypeAccount.TypeProductsId = typeAccount.TypeProductsId;

            _context.Entry(existingTypeAccount).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingTypeAccount;
        }

        public async Task SoftDeleteTypeAccountAsync(int id)
        {
            var typeAccount = await _context.TypeAccounts.FindAsync(id);
            if (typeAccount != null)
            {
                _context.TypeAccounts.Remove(typeAccount);
                await _context.SaveChangesAsync();
            }
        }
    }
}