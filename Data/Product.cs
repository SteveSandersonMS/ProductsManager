using System.ComponentModel.DataAnnotations;

namespace ProductsManager.Data;

#nullable disable
public class Product
{
    public int ProductId { get; set; }
    public long ModifiedTicks { get; set; }
    [Required] public string Category { get; set; }
    [Required] public string Subcategory { get; set; }
    [Required] public string Name { get; set; }
    public string Location { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Stock level cannot be negative")]
    public int Stock { get; set; }

    [Required, Range(1L, 100000000000L, ErrorMessage = "The price must be between $0.01 and $1 billion")]
    public long PriceCents { get; set; }
}
#nullable enable
