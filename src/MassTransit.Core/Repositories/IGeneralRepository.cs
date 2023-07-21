using MassTransit.Core.Shared.BaseInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Core.Repositories
{
    public interface IGeneralRepository<T>
        where T : class
    {
        T Add(T model);
        IQueryable<T> GetAll();
    }
}
