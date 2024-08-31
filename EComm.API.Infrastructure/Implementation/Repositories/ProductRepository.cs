using EComm.API.Infrastructure.DbContexts;
using EComm.API.Infrastructure.Entities;
using EComm.API.Infrastructure.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Implementation.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbSet<Product> _products;
        public ProductRepository(AppDbContext context)
        {
            _products = context.Products;

        }
        public async Task CreateProductAsync(Product product)
        {
            product.CreatedOn = DateTime.Now;
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task DeleteProductAsync(Product product)
        {
               _products.Update(product);
            await Task.CompletedTask;

        }

        public async Task<IEnumerable<Product?>> GetAllProductsAsync()
        {
            return await _products.ToListAsync();
            //.Where(a => a.IsDeleted == false)
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
              return await _products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            product.UpdatedOn = DateTime.Now;
            _products.Update(product);
            await Task.CompletedTask;
        }
    }
}
