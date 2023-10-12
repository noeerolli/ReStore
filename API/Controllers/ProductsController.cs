//using Microsoft.AspNetCore.Components;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {   
        private readonly StoreContext _context;   //inyeccion de dep,podemos usar el context en nuestro controlador 
        public ProductsController(StoreContext context)
        {
            this._context = context;
        }

        //endpoint
        [HttpGet] //traeremos un lista de prod
        public async Task<ActionResult<List<Product>>> GetProducts() 
        {
            return await _context.Products.ToListAsync();
            
        }

        [HttpGet("{id}")] //parameter we´re gonna get from the route - ej api/product/3
        public async Task<ActionResult<Product>> GetProduct(int id) 
        {
            return await _context.Products.FindAsync(id);
        }
 
    }
}
