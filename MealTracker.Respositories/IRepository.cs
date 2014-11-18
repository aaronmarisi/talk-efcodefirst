using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTracker.Repositories
{
    public interface IRepository<T>:IRepository where T : class
    {
        IQueryable<T> All { get; }
        void InsertOrUpdate(T entity);
        void Delete(int id);
    }

    public interface IRepository: IDisposable
    {
        void Save();
    }
}
