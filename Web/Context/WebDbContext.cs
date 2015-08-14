using System.Data.Entity;

namespace Web.Context
{
    public class WebDbContext : DbContext
    {
        public WebDbContext() : base("name=DBConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}