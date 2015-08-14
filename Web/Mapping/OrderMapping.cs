using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Web.Data;

namespace Web.Mapping
{
    public class OrderMapping : EntityTypeConfiguration<Order>
    {
        public OrderMapping()
        {
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(p => p.Products).WithMany();
        }
    }
}