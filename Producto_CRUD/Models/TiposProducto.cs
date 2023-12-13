using System.ComponentModel.DataAnnotations;

namespace Producto_CRUD.Models;

public partial class TiposProducto
{
    public int IdTipo { get; set; }

    [Required(ErrorMessage = "El nombre del tipo de producto es requerido")]
    public string NombreTipo { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
