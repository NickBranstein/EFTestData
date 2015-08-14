using Web.Data;

namespace Web.Factory
{
    public interface ITestDataFactory<T> where T : IEntity
    {
        T[] All();
    }
}
