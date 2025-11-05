using E_Learning.Domain.Comon;

namespace E_Learning.Domain.Entities
{
    public class Product : BaseEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
