using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Web.Data;

namespace Web.Mapping
{
    public class CompanyMapping : EntityTypeConfiguration<Company>
    {
        public CompanyMapping()
        {
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(p => p.Orders);
        }
    }
}