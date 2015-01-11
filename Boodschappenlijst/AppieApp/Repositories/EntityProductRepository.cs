using AppieApp.IRepositories;
using AppieApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace AppieApp.Repositories {

    public class EntityProductRepository : IProductRepository {

        private EntityContext dbContext;

        public EntityProductRepository() {
            dbContext = new EntityContext();
        }

        public Product Get(int productId) {
            return (dbContext.Producten.First(p => p.ProductId == productId));
        }

        public List<Product> GetAll() {
            return dbContext.Producten.ToList();
        }

        public Product Create(Product product) {
            dbContext.Producten.Add(product);
            dbContext.SaveChanges();
            return product;
        }

        public Product Update(Product product) {
            dbContext.Producten.Remove(dbContext.Producten.First(p => p.ProductId == product.ProductId));
            dbContext.Producten.Add(product);
            dbContext.SaveChanges();
            return product;
        }

        public void Delete(Product product) {
            dbContext.Producten.Remove(dbContext.Producten.First(p => p.ProductId == product.ProductId));
            dbContext.SaveChanges();
        }

        public List<Afdeling> GetAllAfdelingen() {
            return dbContext.Afdelingen.ToList();
        }

        public List<Merk> GetAllMerken() {
            return dbContext.Merken.ToList();
        }

    }

}
