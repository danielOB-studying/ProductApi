using System.ComponentModel.DataAnnotations;

namespace ProductApi.DTOs;

public class ProductCreateDto
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor no negativo.")]
    public decimal Price { get; set; }
}

public class ProductUpdateDto
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor no negativo.")]
    public decimal Price { get; set; }
}
