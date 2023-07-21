namespace MassTransit.Core.Repositories
{
    public interface IGeneralRepository<T>
        where T : class
    {
        T Add(T model);
        IQueryable<T> GetAll();
    }
}
