using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AWEPP.Repositories
{
  
    public class SavingRepository : ISavingRepository
    {
        private readonly Aweppcontext _context;

        public SavingRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Saving>> GetAllSavingsAsync()
        {
            return await _context.Savings
                .ToListAsync();
        }

        public async Task<Saving> GetSavingByIdAsync(int id)
        {
#pragma warning disable CS8603
            return await _context.Savings
                .FirstOrDefaultAsync(c => c.Id == id);
#pragma warning disable CS8603
        }

        public async Task<Saving> CreateSavingAsync(Saving saving)
        {
            _context.Savings.Add(saving);
            await _context.SaveChangesAsync();
            return saving;
        }

        public async Task<Saving> UpdateSavingAsync(Saving saving)
        {
            var existingSaving = await _context.Savings.FindAsync(saving.Id);

            if (existingSaving == null)
            {
                throw new NotFoundException("Saving not found");
            }

            // Actualiza las propiedades según sea necesario
            existingSaving.dateStar = saving.dateStar;
            existingSaving.dateEnd = saving.dateEnd;
            existingSaving.SavingAmount = saving.SavingAmount;
            existingSaving.paymentAmount = saving.paymentAmount;
            existingSaving.Description = saving.Description;


            _context.Entry(existingSaving).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return existingSaving;
        }

        public async Task SoftDeleteSavingAsync(int id)
        {
            var saving = await _context.Savings.FindAsync(id);
            if (saving != null)
            {
                _context.Savings.Remove(saving);
                await _context.SaveChangesAsync();
            }
        }
    }
}