using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualStoreBackEnd.Data;
using VirtualStoreBackEnd.Model;

namespace VirtualStoreBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SQLServerContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(SQLServerContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProductAsync()
        {
            try
            {
                return await _context.ProductModel.OrderBy(o => o.Name).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }

        }

        // GET: api/Products/Images
        [HttpGet("/api/ProductsWithImages")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAllProductWithImagesAsync()
        {
            try
            {
                return await _context.ProductModel.Include(e => e.Images.Take(1)).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(e.Message);
            }

        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetByIdAsync(Guid id)
        {
            var productModel = await _context.ProductModel.Include(e => e.Images).FirstOrDefaultAsync(entity => entity.Key == id);

            if (productModel == null)
            {
                return NotFound();
            }

            return productModel;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductModel(Guid id, ProductModel productModel)
        {
            if (id != productModel.Key)
            {
                return BadRequest();
            }

            _context.Entry(productModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductModel>> PostProductModel(ProductModel productModel)
        {
            try
            {
                _context.ProductModel.Add(productModel);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetProductModel", new { id = productModel.Key }, productModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest();
            }
        }

        // POST: api/Product/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Images")]
        public async Task<ActionResult> ImagesProductModel(List<IFormFile> files, Guid productKey)
        {
            var productModel = await _context.ProductModel.FindAsync(productKey);
            if (files.Count == 0 || productModel is null)
                return BadRequest();

            productModel.Images = new List<ImagesModel>();

            foreach (IFormFile file in files)
            {
                using var memoryStream = new MemoryStream();

                await file.CopyToAsync(memoryStream);
                var memoryToArray = memoryStream.ToArray();
                if (memoryToArray.Length > 0)
                {
                    ImagesModel imageModel = new();
                    imageModel.image = memoryToArray;
                    productModel.Images.Add(imageModel);
                }
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            var productModel = await _context.ProductModel.Include(e => e.Images).FirstOrDefaultAsync(entity => entity.Key == id);
            if (productModel == null)
            {
                return NotFound();
            }

            _context.ProductModel.Remove(productModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductModelExists(Guid key)
        {
            return _context.ProductModel.Any(e => e.Key == key);
        }
    }
}
