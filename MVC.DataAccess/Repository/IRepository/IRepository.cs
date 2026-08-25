using System.Linq.Expressions;

namespace MVC.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {

        IEnumerable<T> GetAll(string? includeProp = null);
        T GetValue(Expression<Func<T, bool>> filter, string? includeProp = null);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}