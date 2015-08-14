using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading;
using Web.Data;
using WebGrease.Css.Extensions;

namespace Web.Factory
{
    public class TestDataGenerator
    {
        private List<Tuple<Type, int>> _entityList = new List<Tuple<Type, int>>();
        private readonly DbContext _context;

        public TestDataGenerator(DbContext context)
        {
            _context = context;
            var entities = Assembly.GetAssembly(typeof (IEntity)).GetTypes().Where(t => !t.IsInterface && typeof (IEntity).IsAssignableFrom(t)).Select(t => t);

            foreach (var type in entities)
            {
                CheckDepth(type);
            }
        }

        public void Generate()
        {
            var factories = Assembly.GetAssembly(typeof (ITestDataFactory<>)).GetTypes().Where(t => !t.IsInterface && t.GetInterfaces().Any(i => i.Name == typeof (ITestDataFactory<>).Name));
            var maxDepthList = _entityList.GroupBy(e => e.Item1).Select(g => new {Type = g.Key, Depth = g.Max(m => m.Item2)}).OrderByDescending(o => o.Depth).Select(i => i.Type);

            maxDepthList.ForEach(t =>
            {
                if (factories.Any(f => f.GetInterfaces()[0].GetGenericArguments()[0] == t) && _context.Set(t).ToListAsync(CancellationToken.None).Result.Count == 0)
                {
                    var factory = factories.FirstOrDefault(f => f.GetInterfaces()[0].GetGenericArguments()[0] == t);
                    var factoryObject = factory.GetConstructor(new Type[] {typeof (DbContext)}).Invoke(new object[] {_context});
                    var method = factory.GetMethod("All");
                    var result = method.Invoke(factoryObject, null);

                    _context.Set(t).AddRange((object[]) result);
                    _context.SaveChanges();
                }
            });
        }

        private void CheckDepth(Type type, int currentDepth = 1)
        {
            if (!type.GetProperties().Any(p => typeof (IEntity).IsAssignableFrom(p.PropertyType) ||
                                               (p.PropertyType.IsGenericType && (typeof (IEntity).IsAssignableFrom(p.PropertyType.GetGenericArguments()[0]))) &&
                                               _entityList.Select(t => t.Item1).All(pType => pType != type))) // This is the exit condition so we don't do an infinite loop
            {
                _entityList.Add(new Tuple<Type, int>(type, currentDepth));
            }
            else
            {
                _entityList.Add(new Tuple<Type, int>(type, currentDepth));
                type.GetProperties()
                    .Where(p => typeof (IEntity).IsAssignableFrom(p.PropertyType) || (p.PropertyType.IsGenericType && (typeof (IEntity).IsAssignableFrom(p.PropertyType.GetGenericArguments()[0]))))
                    .ForEach(p =>
                    {
                        if (p.PropertyType.IsGenericType)
                        {
                            var baseType = p.PropertyType.GetGenericArguments()[0];
                            if (typeof (IEntity).IsAssignableFrom(baseType))
                            {
                                CheckDepth(baseType, currentDepth + 1);
                            }
                        }
                        else
                        {
                            CheckDepth(p.PropertyType, currentDepth + 1);
                        }
                    });
            }
        }
    }
}