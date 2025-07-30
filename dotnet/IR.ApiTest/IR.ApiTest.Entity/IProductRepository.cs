using IR.ApiTest.Contracts;
using IR.ApiTest.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IR.ApiTest.Entity
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<Product> AddAsync(Product entity);

        Task<Product> UpdateAsync(Product existing, int id);

        Product MapToModel(ProductEntity entity);
        ProductEntity MapToEntity(Product model);
    }
}
