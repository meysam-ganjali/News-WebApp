namespace News.Application.Repository.IRepository;

public interface IUnitOfWork:IDisposable
{
    //ICategoryRepositry Category { get; }
    Task SaveAsync();
}