using System.Linq.Expressions;

namespace MVC.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        IEnumerable<T> GetAll();
        T GetValue(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}