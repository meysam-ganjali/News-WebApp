using News.Application.Repository.IRepository;
using News.Web.Data;

namespace News.Application.Repository;

public class UnitOfWork:IUnitOfWork
{
    private readonly DatabaseContext _db;

    public UnitOfWork(DatabaseContext db)
    {
        _db = db;
        ParentCategory = new ParentCategoryRepository(_db);
    }

    public IParentCategoryRepository ParentCategory { get; private set; }
   
    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }

    public void Dispose()
    {
        _db.Dispose();
    }
}