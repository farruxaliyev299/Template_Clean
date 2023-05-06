using HackTest.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace HackTest.Domain.Entities
{
    public class Product : BaseAuditableEntity
    {
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
