using AppieApp.IRepositories;
using AppieApp.Model;
using System.Collections.Generic;
using System.Linq;

namespace AppieApp.Repositories {

    public class EntityAfdelingRepository : IAfdelingRepository {

        private EntityContext dbContext;

        public EntityAfdelingRepository() {
            dbContext = new EntityContext();
        }

        public Afdeling Get(int afdelingId) {
            return (dbContext.Afdelingen.First(a => a.AfdelingId == afdelingId));
        }

        public List<Afdeling> GetAll() {
            return dbContext.Afdelingen.ToList();
        }

        public Afdeling Create(Afdeling afdeling) {
            dbContext.Afdelingen.Add(afdeling);
            dbContext.SaveChanges();
            return afdeling;
        }

        public Afdeling Update(Afdeling afdeling) {
            dbContext.Afdelingen.Remove(dbContext.Afdelingen.First(a => a.AfdelingId == afdeling.AfdelingId));
            dbContext.Afdelingen.Add(afdeling);
            dbContext.SaveChanges();
            return afdeling;
        }

        public void Delete(Afdeling afdeling) {
            dbContext.Afdelingen.Remove(dbContext.Afdelingen.First(a => a.AfdelingId == afdeling.AfdelingId));
            dbContext.SaveChanges();
        }

    }

}
