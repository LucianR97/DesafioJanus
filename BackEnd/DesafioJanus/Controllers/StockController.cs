using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public StockController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Stock>> GetStockReport()
    {
        var stockReport = _dbContext.Stock.ToList();
        return Ok(stockReport);
    }
}
