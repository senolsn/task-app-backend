using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using Entities.Concrete;

namespace DataAccess.Abstracts
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<IQueryable<Product>> GetAllProductsForDx();
    }
}
