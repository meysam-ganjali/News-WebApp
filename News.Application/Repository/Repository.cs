using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using News.Application.Repository.IRepository;
using News.Utility;
using News.Web.Data;

namespace News.Application.Repository;

public class Repository<T>:IRepository<T>where T : class
{
    private readonly DatabaseContext _db;
    internal DbSet<T> dbSet;

    public Repository(DatabaseContext db)
    {
        _db = db;
        this.dbSet = db.Set<T>();
    }

    public async Task<ResultDto> Add(T entity)
    {
        try
        {
            dbSet.Add(entity);
            return new ResultDto
            {
                Message = "عملیات ثبت با موفقیت انجام شد",
                Status = true
            };
        }
        catch (Exception e)
        {
            return new ResultDto
            {
                Message = e.Message,
                Status = false
            };
        }
    }

    public async Task<ResultDto> Remove(T entity)
    {
        try
        {
            dbSet.Remove(entity);
            return new ResultDto
            {
                Message = "عملیات ثبت با موفقیت انجام شد",
                Status = true
            };
        }
        catch (Exception e)
        {
            return new ResultDto
            {
                Message = e.Message,
                Status = false
            };
        }
    }

    public async Task<ResultDto> RemoveRange(IEnumerable<T> entity)
    {
        try
        {
            dbSet.RemoveRange(entity);
            return new ResultDto
            {
                Message = "عملیات ثبت با موفقیت انجام شد",
                Status = true
            };
        }
        catch (Exception e)
        {
            return new ResultDto
            {
                Message = e.Message,
                Status = false
            };
        }
    }

    public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (includeProperties != null)
        {
            //abc,,xyz -> abc xyz
            foreach (var includeProperty in includeProperties.Split(
                         new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }
        if (orderby != null)
        {
            return await orderby(query).ToListAsync();
        }
        return await query.ToListAsync();
    }

    public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if (filter != null)
        {
            query = query.Where(filter);
        }
        if (includeProperties != null)
        {
            //abc,,xyz -> abc xyz
            foreach (var includeProperty in includeProperties.Split(
                         new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }
        return query.FirstOrDefault();
    }
}