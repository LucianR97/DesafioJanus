using System.ComponentModel.DataAnnotations;

public class Producto
{
    [Key]
    public int Id { get; set; }

    public int IdTipoProducto { get; set; }

    public string Nombre { get; set; }

    public decimal Precio { get; set; }
}
