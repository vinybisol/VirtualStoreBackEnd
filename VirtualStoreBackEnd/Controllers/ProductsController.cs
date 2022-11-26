using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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
        [DisableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetProductModel()
        {
            return await _context.ProductModel.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> GetProductModel(Guid id)
        {
            var productModel = await _context.ProductModel.FindAsync(id);

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
            if (id != productModel._id)
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
            _context.ProductModel.Add(productModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductModel", new { id = productModel._id }, productModel);
        }

        // POST: api/Product/Images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("Images")]
        public async Task<ActionResult> ImagesProductModel(List<IFormFile> files)
        {

            if (files.Count == 0)
                return BadRequest();
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");

            foreach (IFormFile file in files)
            {
                string filePath = Path.Combine(directoryPath, Guid.NewGuid().ToString());
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            ImagesModel imageModel = new();
            imageModel.ProductId = Guid.NewGuid();
            foreach (IFormFile file in files)
            {
                using (var memoryStream = new MemoryStream())
                {
                  await file.CopyToAsync(memoryStream);
                    var memoryToArray = memoryStream.ToArray();
                    if(memoryToArray.Length > 0)
                    {
                        imageModel.images1 = memoryToArray;
                        await _context.ImagesModel.AddAsync(imageModel);
                        await _context.SaveChangesAsync();
                    }
                   
                }
            }

  


            return Ok();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductModel(Guid id)
        {
            var productModel = await _context.ProductModel.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }

            _context.ProductModel.Remove(productModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductModelExists(Guid id)
        {
            return _context.ProductModel.Any(e => e._id == id);
        }
    }
}
