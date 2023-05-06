using HackTest.Domain.Common;

namespace HackTest.Domain.Entities;

public class Category : BaseAuditableEntity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
