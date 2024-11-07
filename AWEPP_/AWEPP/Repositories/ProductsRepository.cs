using AWEPP.Context;
using AWEPP.Model;
using AWEPP.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWEPP.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly Aweppcontext _context;

        public ProductsRepository(Aweppcontext context)
        {
            _context = context;
        }

        public async Task CreateProductsAsync(Products products)
        {
            await _context.Productss.AddAsync(products); // Añadir nuevo registro
            await _context.SaveChangesAsync(); // Guardar cambios
        }

        public async Task<IEnumerable<Products>> GetAllProductsAsync()
        {
            return await _context.Productss
                .Where(s => !s.IsDeleted) // Excluir los eliminados
                .ToListAsync();
        }

        public async Task<Products> GetProductsByIdAsync(int Id)
        {
            return await _context.Productss
                 .FirstOrDefaultAsync(s => s.Id == Id && !s.IsDeleted);
        }

        public async Task SoftDeleteProductsAsync(int Id)
        {
            var expenses = await _context.Productss.FindAsync(Id);
            if (expenses != null)
            {
                expenses.IsDeleted = true; // Marcar como eliminado
                await _context.SaveChangesAsync(); // Guardar cambios
            }
        }

        public async Task UpdateProductsAsync(Products products)
        {
            var existingProduct = await _context.Productss.FindAsync(products.Id);
            if (existingProduct != null)
            {
                // Actualizar los campos necesarios
                existingProduct.TypeAccounts = products.TypeAccounts;
                existingProduct.TypeProducts = products.TypeProducts;
                existingProduct.Bank = products.Bank;
                existingProduct.Account = products.Account;
                existingProduct.NumberAccount = products.NumberAccount;
                existingProduct.TotalBalance = products.TotalBalance;
                existingProduct.PartialBalance = products.PartialBalance;
                existingProduct.Debt = products.Debt;
                existingProduct.DatePayment = products.DatePayment;
                existingProduct.Description = products.Description;
                existingProduct.Customer = products.Customer;

                // Guardar cambios en la base de datos
                await _context.SaveChangesAsync();
            }
        }
    }

}




     
