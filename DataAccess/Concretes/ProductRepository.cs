using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Concretes
{
    public class ProductRepository : RepositoryBase<Product, BaseNArchitectureContext>, IProductRepository
    {
        private readonly BaseNArchitectureContext _context;
        public ProductRepository(BaseNArchitectureContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Product>> GetAllProductsForDx()
        {
            var data = _context.Products.Where(x => x.IsActive);
            return await Task.FromResult(data);
        }
    }
}
