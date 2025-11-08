using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_Learning.Domain.Entities;
public class ApplicationUser : IdentityUser<Guid>
{
    [MaxLength(100)]
    public string FullName { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
