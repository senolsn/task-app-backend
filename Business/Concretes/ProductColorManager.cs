using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Request.ProductColor;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrete;

namespace Business.Concretes
{
    public class ProductColorManager : IProductColorService
    {
        protected readonly IMapper _mapper;
        protected readonly IProductColorRepository _productColorRepository;

        public ProductColorManager(IMapper mapper, IProductColorRepository productColorRepository)
        {
            _mapper = mapper;
            _productColorRepository = productColorRepository;
        }

        public async Task<IResult> Add(CreateProductColorRequest request)
        {
            var entity = _mapper.Map<ProductColor>(request);

            var createdEntity = await _productColorRepository.AddAsync(entity);

            if(createdEntity is null)
            {
                return new ErrorResult(Messages.Error);
            }

            return new SuccessResult(Messages.Added);
        }

        public async Task<IResult> Delete(DeleteProductColorRequest request)
        {
            var entity = await _productColorRepository.GetAsync(x => x.Id == request.Id);

            if(entity is null)
            {
                return new ErrorResult(Messages.Error);
            }

            await _productColorRepository.DeleteAsync(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IResult> Update(UpdateProductColorRequest request)
        {
            var entity = await _productColorRepository.GetAsync(x => x.Id == request.Id);

            if (entity is null)
            {
                return new ErrorResult(Messages.Error);

            }
            _mapper.Map(request, entity);
            await _productColorRepository.UpdateAsync(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
