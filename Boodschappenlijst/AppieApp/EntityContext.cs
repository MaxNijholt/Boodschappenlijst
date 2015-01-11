using AppieApp.Model;
using System.Data.Entity;

namespace AppieApp {

    public class EntityContext : DbContext {

        public EntityContext() : base("name=EntityContext") {
        }

        public DbSet<Afdeling>  Afdelingen  { get; set; }
        public DbSet<Korting>   Kortingen   { get; set; }
        public DbSet<Merk>      Merken      { get; set; }
        public DbSet<Product>   Producten   { get; set; }

    }

}
