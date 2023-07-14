using System.ComponentModel.DataAnnotations;

public class Stock
{
    [Key]
    public int Id { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }
}
