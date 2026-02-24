
using System.ComponentModel.DataAnnotations.Schema;
using Web_Api_Amazon.Entities;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int? ParentCategoryId { get; set; }
    public Category ParentCategory { get; set; }

    public ICollection<CategoryProperty> CategoryProperties { get; set; } = new List<CategoryProperty>();
    public ICollection<Category> SubCategories { get; set; } = new List<Category>();
    public ICollection<Product> Products { get; set; } = new List<Product>();
}