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
    public class ProductSqlRepository : IProductRepository
    {
        private readonly DbSet<Product> _products;
        public ProductSqlRepository(AppDbContext context)
        {
            _products = context.Products;

        }
        public async Task CreateProductAsync(Product product)
        {
            product.CreatedOn = DateTimeOffset.Now;
            _products.Add(product);
            await Task.CompletedTask;
        }

        public async Task DeleteProductAsync(Product product)
        {
               _products.Remove(product);
            await Task.CompletedTask;

        }

        public async Task<IEnumerable<Product?>> GetAllProductsAsync()
        {
            return await _products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(Guid id)
        {
              return await _products.FindAsync(id);
        }

        public async Task UpdateProductAsync(Product product , Guid id)
        {
            var productById = await GetProductByIdAsync(id);
            productById.UpdatedOn = DateTimeOffset.Now;
            _products.Update(productById);
            await Task.CompletedTask;
        }
    }
}
