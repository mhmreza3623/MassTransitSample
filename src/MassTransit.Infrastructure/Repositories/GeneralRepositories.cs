using MassTransit.Core.Repositories;
using MassTransit.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace MassTransit.Infrastructure.Repositories
{
    internal class GeneralRepositories<T> : IGeneralRepository<T> where T : class
    {
        private readonly DbSet<T> dbset;
        private readonly AppDbContext context;

        public GeneralRepositories(AppDbContext appDbContext)
        {
            context = appDbContext;
            dbset = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return dbset.AsQueryable<T>();
        }

        public T Add(T model)
        {
            dbset.Add(model);
            context.SaveChanges();
            return model;
        }
    }
}

