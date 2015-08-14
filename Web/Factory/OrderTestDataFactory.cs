using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web.Data;
using WebGrease.Css.Extensions;

namespace Web.Factory
{
    public class OrderTestDataFactory : ITestDataFactory<Order>
    {
        private Order[] _orders;
        private readonly DbContext _context;

        public OrderTestDataFactory(DbContext context)
        {
            _context = context;
        }

        public Order[] All()
        {
            return _orders ?? (_orders = Generate());
        }

        private Order[] Generate()
        {
            var orders = new List<Order>();
            _context.Set<Company>().ForEach(c => orders.Add(new Order() {Company = c, Number = $"{c.Name}-{new Guid().ToString()}", Products = _context.Set<Product>().ToList()}));

            return orders.ToArray();
        }
    }
}