using System.Data.Entity;
using System.Reflection;

namespace OracleTest.Entity
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(): base("OracleDbContext")
        {
            Database.SetInitializer<OracleDbContext>(null);
        }

        public DbSet<KISILER> Kisi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SYSTEM");
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
