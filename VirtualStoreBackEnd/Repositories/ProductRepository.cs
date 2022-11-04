using Microsoft.EntityFrameworkCore;
using VirtualStoreBackEnd.Data;
using VirtualStoreBackEnd.Model;

namespace VirtualStoreBackEnd.Repositories
{
    public interface IProductRepository : IDisposable
    {
        Task<ProductModel> AddAsync(ProductModel productModel);
        Task<List<ProductModel>> GetAllAsync();
        Task<ProductModel> GetByIdAsync(Guid id);
        Task<ProductModel> UpdateAsync(ProductModel productModel);
    }

    internal class ProductRepository : IProductRepository,IDisposable
    {
        private readonly SQLServerContext _context;

        public ProductRepository(SQLServerContext context)
        {
            _context = context;
        }

        public async Task<ProductModel> AddAsync(ProductModel productModel)
        {
            _context.ProductModel.Add(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }


        public async Task<List<ProductModel>> GetAllAsync() => await _context.ProductModel.ToListAsync();


        public async Task<ProductModel> GetByIdAsync(Guid id) => await _context.ProductModel.FindAsync(id);

        public async Task<ProductModel> UpdateAsync(ProductModel productModel)
        {
            _context.Entry(productModel).State = EntityState.Modified;
            return productModel;
         
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
