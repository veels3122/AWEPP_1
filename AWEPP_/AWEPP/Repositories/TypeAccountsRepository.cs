using AWEPP.Context;
using AWEPP.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{


    public class TypeAccountsRepository : ITypeAccountsRepository
    {
        private readonly Aweppcontext _context;

        public TypeAccountsRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeAccounts>> GetAllTypeAccountsAsync()
        {
            return await _context.Accounts
                .ToListAsync();
        }

        public async Task<TypeAccounts> GetTypeAccountByIdAsync(int id)
        {
#pragma warning disable CS8603
            return await _context.Accounts
                .FirstOrDefaultAsync(c => c.Id == id);
#pragma warning disable CS8603
        }

        public async Task<TypeAccounts> CreateTypeAccountAsync(TypeAccounts typeAccounts)
        {
            _context.Accounts.Add(typeAccounts);
            await _context.SaveChangesAsync();
            return typeAccounts;
        }

        public async Task<TypeAccounts> UpdateTypeAccountAsync(TypeAccounts typeAccounts)
        {
            var existingTypeAccounts = await _context.Accounts.FindAsync(typeAccounts.Id);

            if (existingTypeAccounts == null)
            {
                throw new NotFoundException("TypeAccount not found");
            }

            existingTypeAccounts.Accounts = typeAccounts.Accounts;
            existingTypeAccounts.Typeproducts = typeAccounts.Typeproducts;

            _context.Entry(existingTypeAccounts).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingTypeAccounts;
        }

        public async Task SoftDeleteTypeAccountAsync(int id)
        {
            var typeAccounts = await _context.Accounts.FindAsync(id);
            if (typeAccounts != null)
            {
                _context.Accounts.Remove(typeAccounts);
                await _context.SaveChangesAsync();
            }
        }
    }
}