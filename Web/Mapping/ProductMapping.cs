using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Web.Data;

namespace Web.Mapping
{
    public class ProductMapping : EntityTypeConfiguration<Product>
    {
        public ProductMapping()
        {
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}