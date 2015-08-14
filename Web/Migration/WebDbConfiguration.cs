using System.Data.Entity.Migrations;
using Web.Context;
using Web.Factory;

namespace Web.Migration
{
    internal sealed class WebDbConfiguration : DbMigrationsConfiguration<WebDbContext>
    {
        public WebDbConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WebDbContext context)
        {
            var generator = new TestDataGenerator(new WebDbContext());

            generator.Generate();
        }
    }
}