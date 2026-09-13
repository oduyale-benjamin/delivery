using System.ComponentModel.DataAnnotations;


namespace pizza.Models;

public class Pizza
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;

}
