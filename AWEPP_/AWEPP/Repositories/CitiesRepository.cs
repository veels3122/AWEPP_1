using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Modelo;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class CitiesRepository : ICitiesRepository
    {
        private readonly Aweppcontext _context;

        public CitiesRepository(Aweppcontext context)
        {
            _context = context;
        }
        public async Task CreateCitiesAsync(Cities Cities)
        {
            await _context.Cities.AddAsync(Cities); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }

        public async Task<IEnumerable<Cities>> GetAllCitiesAsync()
        {
            return await _context.Cities
               .Where(s => !s.IsDeleted) // Excluir los eliminados
               .ToListAsync();
        }

        public async Task<Cities> GetCitiesByIdAsync(int Id)
        {
            return await _context.Cities
                .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }

        public async Task SoftDeleteCitiesAsync(int Id)
        {
            var Cities = await _context.Cities.FindAsync(Id);
            if (Cities != null)
            {
                Cities.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }

        public async Task UpdateCitiesAsync(Cities Cities)
        {
            var existingBank = await _context.Cities.FindAsync(Cities.Id);
            if (existingBank != null)
            {
                // Actualizar campos
                existingBank.City = Cities.City;
                existingBank.IsDeleted = Cities.IsDeleted;


                // Guardar cambios
                await _context.SaveChangesAsync();
            }
        }
    }
}

  
   

