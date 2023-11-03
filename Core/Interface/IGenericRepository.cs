
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Interface;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<(int totalRegistros, IEnumerable<T> registros)> paginacion(int pageIndex, int pageSize, string _search);
    Task<T> GetById(int id);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
}
