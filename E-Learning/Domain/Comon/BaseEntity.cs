using System.ComponentModel.DataAnnotations;

namespace E_Learning.Domain.Comon
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } 

        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
