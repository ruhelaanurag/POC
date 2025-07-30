using IR.ApiTest.Contracts;
using IR.ApiTest.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace IR.ApiTest.Entity
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiContext context;
        public ProductRepository(ApiContext _context)
        {
            context = _context;
        }
        public Task<Product> AddAsync(Product product)
        {
                product.Created = DateTime.Now;
                product.LastUpdated = DateTime.Now;
                var entity = context.Products.Add(MapToEntity(product)).Entity;
                context.SaveChangesAsync();
                return Task.FromResult(MapToModel(entity));
        }

        public Task<List<Product>> GetAllAsync()
        {
                var list = context.Set<ProductEntity>().AsNoTracking().Select(x=> MapToModel(x)).ToListAsync();
                return list;
        }

        public Task<Product?> GetByIdAsync(int id)
        {
                var list = context.Products.AsNoTracking().FirstOrDefault(x => x.Id == id);
                var result = MapToModel(list);
                return Task.FromResult(result);
        }

        public Task<Product> UpdateAsync(Product updated, int id)
        {
                var existing = GetByIdAsync(id).Result;
                updated.LastUpdated = DateTime.Now;
                updated.Created = existing.Created;
                updated.Id = existing.Id;
                var entity = context.Products.Update(MapToEntity(updated)).Entity;
                context.SaveChangesAsync();
                return Task.FromResult(MapToModel(entity));
        }

        public Product MapToModel(ProductEntity entity)
        {
            Product product = new Product();
            if (entity == null)
                return null;
            product.Id = entity.Id;
            product.Name = entity.Name;
            product.Price = entity.Price;
            product.Category = entity.Category;
            product.Created = entity.Created;
            product.LastUpdated = entity.LastUpdated;
            return product;
        }

        public ProductEntity MapToEntity(Product model)
        {
            ProductEntity productEntity = new ProductEntity();
            if(model == null)
                return null;
            productEntity.Id = model.Id;
            productEntity.Name = model.Name;
            productEntity.Price = model.Price;
            productEntity.Category = model.Category;
            productEntity.Created = model.Created;
            productEntity.LastUpdated = model.LastUpdated;
            return productEntity;
        }

    }
}
