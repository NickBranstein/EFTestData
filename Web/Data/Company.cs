
using System.Collections.Generic;

namespace Web.Data
{
    public class Company : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}