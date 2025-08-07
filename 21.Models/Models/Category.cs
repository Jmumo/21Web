using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _21.Models.Models;

public class Category
{   
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Category Name")]
    [StringLength(30, ErrorMessage = "Name must be between 1 and 50 characters")]
    public string Name { get; set; }
    [Required]
    [DisplayName("Category Description")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 200 characters")]
    public string Description { get; set; }
    [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100")]
    [DisplayName("Display Order")]
    public int DisplayOrder { get; set; }
}