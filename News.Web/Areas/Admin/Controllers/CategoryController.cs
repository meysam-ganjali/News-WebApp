using Microsoft.AspNetCore.Mvc;
using News.Application.Repository.IRepository;

namespace News.Web.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var menuItemList = await _unitOfWork.ParentCategory.GetAll(includeProperties: "NewsCategories");
            return View(menuItemList);
        }
    }
}
