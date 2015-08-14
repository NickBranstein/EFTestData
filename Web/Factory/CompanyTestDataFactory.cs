using System.Data.Entity;
using System.Linq;
using Web.Data;

namespace Web.Factory
{
    public class CompanyTestDataFactory : ITestDataFactory<Company>
    {
        private Company[] _companies;
        private readonly DbContext _context;

        public CompanyTestDataFactory(DbContext context)
        {
            _context = context;
        }

        public Company[] All()
        {
            return _companies ?? (_companies = Generate());
        }
 
        private static Company[] Generate()
        {
            return new Company[]
            {
                new Company() {Name = "Acme Co."},
                new Company() {Name = "Professional Builders"},
                new Company() {Name = "Bobcat Inc."},
                new Company() {Name = "Amazing Works"}
            };
        }
    }
}