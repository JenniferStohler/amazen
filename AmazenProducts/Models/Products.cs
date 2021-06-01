using System.ComponentModel.DataAnnotations;

namespace AmazenProducts.Models
{
  public class Products
  {
    public int Id { get; set; }
    public string Name { get; set; }
    [Required]
    public int Price { get; set; }

    public string Description { get; set; }

    public int Quantity { get; set; }
  }
}