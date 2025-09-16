using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace _21.Models.Models;

public class ApplicationUser:IdentityUser
{   [Required]
    public string Name { get; set; }
    
    public String ? StreetAddress { get; set; }
    public String ? city { get; set; }
    public String ? State { get; set; }
    public String ? PostalCode { get; set; }
}