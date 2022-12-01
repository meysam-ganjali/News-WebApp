using System.ComponentModel.DataAnnotations;

namespace News.Domain.Models;

public class ParentCategory
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "عنوان دسته بندی را وارد نکرده اید")]
    [MaxLength(500, ErrorMessage = "تعداد کاراکتر مجاز برای عنوان دسته 500 کاراکتر می باشد")]
    public string Name { get; set; }
    public string? LogoPath { get; set; }
    public ICollection<NewsCategory> NewsCategories { get; set; }
}