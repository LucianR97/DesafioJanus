using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public ProductosController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Producto>> GetProductos()
    {
        var productos = _dbContext.Productos.ToList();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public ActionResult<Producto> GetProducto(int id)
    {
        var producto = _dbContext.Productos.FirstOrDefault(p => p.Id == id);
        if (producto == null)
        {
            return NotFound();
        }
        return Ok(producto);
    }

    [HttpPost]
    public ActionResult<Producto> CreateProducto([FromBody] Producto producto)
    {
        _dbContext.Productos.Add(producto);
        _dbContext.SaveChanges();
        return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateProducto(int id, [FromBody] Producto producto)
    {
        if (id != producto.Id)
        {
            return BadRequest();
        }

        _dbContext.Entry(producto).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProducto(int id)
    {
        var producto = _dbContext.Productos.FirstOrDefault(p => p.Id == id);
        if (producto == null)
        {
            return NotFound();
        }

        _dbContext.Productos.Remove(producto);
        _dbContext.SaveChanges();
        return NoContent();
    }
}
