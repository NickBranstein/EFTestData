using System.Data.Entity;
using Web.Data;

namespace Web.Factory
{
    public class ProductTestDataFactory : ITestDataFactory<Product>
    {
        private Product[] _products;
        private readonly DbContext _context;

        public ProductTestDataFactory(DbContext context)
        {
            _context = context;
        }

        public Product[] All()
        {
            return _products ?? (_products = Generate());
        }

        private static Product[] Generate()
        {
            return new Product[]
            {
                new Product() {Name = "Pipe Bender" },
                new Product() {Name = "Blender" },
                new Product() {Name = "Game Console" },
                new Product() {Name = "Frying Pan" },
                new Product() {Name = "TV" },
                new Product() {Name = "Ice Maker" },
                new Product() {Name = "Bookcase" }
            };
        }
    }
}