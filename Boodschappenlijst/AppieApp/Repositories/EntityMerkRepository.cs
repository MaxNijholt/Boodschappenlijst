using AppieApp.IRepositories;
using AppieApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace AppieApp.Repositories {

    public class EntityMerkRepository : IMerkRepository {

        private EntityContext dbContext;

        public EntityMerkRepository() {
            dbContext = new EntityContext();
        }

        public Merk Get(int merkId) {
            return (dbContext.Merken.First(m => m.MerkId == merkId));
        }

        public List<Merk> GetAll() {
            return dbContext.Merken.ToList();
        }

        public Merk Create(Merk merk) {
            dbContext.Merken.Add(merk);
            dbContext.SaveChanges();
            return merk;
        }

        public Merk Update(Merk merk) {
            dbContext.Merken.Remove(dbContext.Merken.First(m => m.MerkId == merk.MerkId));
            dbContext.Merken.Add(merk);
            dbContext.SaveChanges();
            return merk;
        }

        public void Delete(Merk merk) {
            dbContext.Merken.Remove(dbContext.Merken.First(m => m.MerkId == merk.MerkId));
            dbContext.SaveChanges();
        }

    }

}
