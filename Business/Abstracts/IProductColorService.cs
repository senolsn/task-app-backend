using System.Threading.Tasks;
using Business.Dtos.Request.ProductColor;
using Core.Utilities.Results;

namespace Business.Abstracts
{
    public interface IProductColorService
    {
        Task<IResult> Add(CreateProductColorRequest request);
        Task<IResult> Update(UpdateProductColorRequest request);
        Task<IResult> Delete(DeleteProductColorRequest request);
    }
}
