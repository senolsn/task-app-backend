using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

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
            var data = _context.Products.Where(x => x.IsActive && x.DeletedDate == null);
            return await Task.FromResult(data);
        }

        public async Task<Product?> GetProductById(Guid id)
        {
            try
            {
                return await _context.Products
                .Include(p => p.ProductColors)
                .FirstOrDefaultAsync(p => p.Id == id);

            }
            catch (Exception ex)
            {

                throw ex;
            } 
            
        }

        public async override Task<Product?> GetAsync(Expression<Func<Product, bool>> predicate, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            var queryable = base.Context.Products.AsQueryable();

            queryable = queryable.Include(p => p.ProductColors);

            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();
            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);

        }
    }
}
