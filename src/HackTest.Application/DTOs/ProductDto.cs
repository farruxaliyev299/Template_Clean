using System.ComponentModel.DataAnnotations;

namespace HackTest.Application.DTOs;

public class ProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public CategoryDto Category { get; set; }
}
