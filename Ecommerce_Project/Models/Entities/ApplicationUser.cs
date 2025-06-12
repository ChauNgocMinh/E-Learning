using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_Project.Models.Entities;
public class ApplicationUser : IdentityUser<Guid>
{
    [MaxLength(100)]
    public string FullName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
