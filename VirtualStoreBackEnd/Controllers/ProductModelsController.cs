using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VirtualStoreBackEnd.Context;
using VirtualStoreBackEnd.Model;

namespace VirtualStoreBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductModelsController : ControllerBase
    {
        private readonly PostgresContext _context;

        public ProductModelsController(PostgresContext context)
        {
            _context = context;
        }

        // GET: ProductModels
        [HttpGet(Name = "ProductModels")]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.ProductModel.ToListAsync());
        }

        //    // GET: ProductModels/Details/5
        //    public async Task<IActionResult> Details(string id)
        //    {
        //        if (id == null || _context.ProductModel == null)
        //        {
        //            return NotFound();
        //        }

        //        var productModel = await _context.ProductModel
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (productModel == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(productModel);
        //    }

        //    // GET: ProductModels/Create
        //    public IActionResult Create()
        //    {
        //        return Ok();
        //    }

        //    // POST: ProductModels/Create
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Create([Bind("Id,Full_name,Name,Price,Market_price,Tag_id,Obs,Market_obs,Created_at,Update_at")] ProductModel productModel)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(productModel);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return Ok(productModel);
        //    }

        //    // GET: ProductModels/Edit/5
        //    public async Task<IActionResult> Edit(string id)
        //    {
        //        if (id == null || _context.ProductModel == null)
        //        {
        //            return NotFound();
        //        }

        //        var productModel = await _context.ProductModel.FindAsync(id);
        //        if (productModel == null)
        //        {
        //            return NotFound();
        //        }
        //        return Ok(productModel);
        //    }

        //    // POST: ProductModels/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(string id, [Bind("Id,Full_name,Name,Price,Market_price,Tag_id,Obs,Market_obs,Created_at,Update_at")] ProductModel productModel)
        //    {
        //        if (id != productModel.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(productModel);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!ProductModelExists(productModel.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return Ok(productModel);
        //    }

        //    // GET: ProductModels/Delete/5
        //    public async Task<IActionResult> Delete(string id)
        //    {
        //        if (id == null || _context.ProductModel == null)
        //        {
        //            return NotFound();
        //        }

        //        var productModel = await _context.ProductModel
        //            .FirstOrDefaultAsync(m => m.Id == id);
        //        if (productModel == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(productModel);
        //    }

        //    // POST: ProductModels/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(string id)
        //    {
        //        if (_context.ProductModel == null)
        //        {
        //            return Problem("Entity set 'PostgresContext.ProductModel'  is null.");
        //        }
        //        var productModel = await _context.ProductModel.FindAsync(id);
        //        if (productModel != null)
        //        {
        //            _context.ProductModel.Remove(productModel);
        //        }

        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool ProductModelExists(string id)
        //    {
        //        return _context.ProductModel.Any(e => e.Id == id);
        //    }
    }
}
