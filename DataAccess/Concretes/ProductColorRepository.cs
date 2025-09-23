
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concrete;

namespace DataAccess.Concretes
{
    public class ProductColorRepository : RepositoryBase<ProductColor, BaseNArchitectureContext>, IProductColorRepository
    {
        private readonly BaseNArchitectureContext _context;

        public ProductColorRepository(BaseNArchitectureContext context) : base(context)
        {
            _context = context;
        }
    }
}
