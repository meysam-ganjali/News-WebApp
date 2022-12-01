using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace News.Domain.Models;

public class NewsCategory
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "عنوان دسته بندی را وارد نکرده اید")]
    [MaxLength(500,ErrorMessage = "تعداد کاراکتر مجاز برای عنوان دسته 500 کاراکتر می باشد")]
    public string Name { get; set; }
    public string? LogoPath { get; set; }
    public int ParentCategoryId { get; set; }
    [ForeignKey("ParentCategoryId")]
    public ParentCategory ParentCategory { get; set; }
    public ICollection<Newspaper> Newspapers { get; set; }
}