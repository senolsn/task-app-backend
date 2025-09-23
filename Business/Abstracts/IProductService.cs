using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Dtos.Request.Product;
using Business.Dtos.Response.Product;
using Core.Utilities.Results;

namespace Business.Abstracts
{
    public interface IProductService
    {
        Task<IResult> Add(CreateProductRequest request);
        Task<IResult> Update(UpdateProductRequest request);
        Task<IResult> Delete(DeleteProductRequest request);
        Task<IDataResult<IQueryable<GetAllProductResponse>>> GetAllProductsForDx();
        Task<IDataResult<IEnumerable<GetAllProductResponse>>> GetAllProducts();
    }
}
