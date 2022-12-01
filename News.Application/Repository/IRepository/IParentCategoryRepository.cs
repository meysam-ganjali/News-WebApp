using News.Domain.Models;
using News.Utility;

namespace News.Application.Repository.IRepository;

public interface IParentCategoryRepository:IRepository<ParentCategory>
{
    Task<ResultDto> UpdateAsync(ParentCategory parentCategory);
}