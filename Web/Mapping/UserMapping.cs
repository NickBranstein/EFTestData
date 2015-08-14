using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Web.Data;

namespace Web.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}