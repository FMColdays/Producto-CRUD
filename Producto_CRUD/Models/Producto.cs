using System.ComponentModel.DataAnnotations;

namespace Producto_CRUD.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    [Required(ErrorMessage = "El nombre del producto es requerido")]
    public string NombreProducto { get; set; } = null!;

    [Required(ErrorMessage = "La descripción del producto es requerido")]
    public string? DescripcionProducto { get; set; }

    [Required(ErrorMessage = "El precio del producto es requerido")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "El stock del producto es requerido")]
    public int Stock { get; set; }

    public int? IdTipoProducto { get; set; }

    public virtual TiposProducto? IdTipoProductoNavigation { get; set; }
}
