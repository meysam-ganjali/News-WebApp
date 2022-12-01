namespace News.Application.Repository.IRepository;

public interface IUnitOfWork:IDisposable
{
    IParentCategoryRepository ParentCategory { get; }
    Task SaveAsync();
}