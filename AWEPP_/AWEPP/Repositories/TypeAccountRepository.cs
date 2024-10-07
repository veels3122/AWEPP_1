using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class TypeAccountRepository : ITypeAccountRepository
    {
        public Task CreateTypeAccountsAsync(TypeAccount typeAccounts)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TypeAccount>> GetAllTypeAccountsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TypeAccount> GetTypeAccountsByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task SoftDeleteTypeAccountsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTypeAccountsAsync(TypeAccount typeAccounts)
        {
            throw new NotImplementedException();
        }
    }
}





