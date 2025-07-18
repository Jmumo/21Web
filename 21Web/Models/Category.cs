using System.ComponentModel.DataAnnotations;

namespace _21Web.Models;

public class Category
{   
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public int DisplayOrder { get; set; }
}