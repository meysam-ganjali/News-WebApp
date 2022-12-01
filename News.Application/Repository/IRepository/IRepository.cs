using News.Utility;
using System.Linq.Expressions;

namespace News.Application.Repository.IRepository;

public interface IRepository<T> where T : class
{
    Task<ResultDto> Add(T entity);
    Task<ResultDto> Remove(T entity);
    Task<ResultDto> RemoveRange(IEnumerable<T> entity);
    Task<IEnumerable<T>> GetAll(

        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null,
        string? includeProperties = null
        );
    Task<T> GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
}