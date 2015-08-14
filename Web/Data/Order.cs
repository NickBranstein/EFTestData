using System.Collections.Generic;

namespace Web.Data
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Company Company { get; set; }
    }
}