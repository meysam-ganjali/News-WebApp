using System.ComponentModel.DataAnnotations.Schema;

namespace News.Domain.Models;

public class Newspaper
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string NewsText { get; set; }
    public int NewsLike { get; set; } = 0;
    public int NewsDeslike { get; set; }=0;
    public int NewsShowCount { get; set; }=0;
    public DateTime CreateNewsDate { get; set; }=DateTime.Now;
    public int NewsCategoryId { get; set; }
    public string NewsCoverImagePath { get; set; }
    [ForeignKey("NewsCategoryId")]
    public NewsCategory NewsCategory { get; set; }

}