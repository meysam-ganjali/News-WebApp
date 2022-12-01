using News.Application.Repository.IRepository;
using News.Domain.Models;
using News.Utility;
using News.Web.Data;

namespace News.Application.Repository;

public class ParentCategoryRepository:Repository<ParentCategory>,IParentCategoryRepository
{
    private readonly DatabaseContext _db;

    public ParentCategoryRepository(DatabaseContext db) : base(db)
    {
        _db = db;
    }
    public async Task<ResultDto> UpdateAsync(ParentCategory parentCategory)
    {
        var parentCategoryFromDb = await _db.ParentCategories.FindAsync(parentCategory.Id);
        if (parentCategoryFromDb == null)
        {
            return new ResultDto
            {
                Message = "دسته بندی یافت نشد",
                Status = false
            };
        }
        if (!string.IsNullOrWhiteSpace(parentCategory.LogoPath))
        {
            parentCategoryFromDb.LogoPath=parentCategory.LogoPath;
        }
        parentCategoryFromDb.Name=parentCategory.Name;
        return new ResultDto
        {
            Message = "دسته بندی یافت بروز شد",
            Status = true
        };
    }
}