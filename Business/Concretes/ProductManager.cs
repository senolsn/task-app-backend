using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Business.Abstracts;
using Business.Constants;
using Business.Dtos.Request.Product;
using Business.Dtos.Response.Product;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concrete;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductManager(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IResult> Add(CreateProductRequest request)
        {
            var entity = _mapper.Map<Product>(request);

            foreach (var color in request.ProductColors)
            {
                entity.ProductColors.Add(new ProductColor
                {
                    Id = Guid.NewGuid(),
                    ColorName = color.ColorName,
                    ColorCode = color.ColorCode,
                    CreatedDate = DateTime.Now
                });
            }

            await _productRepository.AddAsync(entity); 
            await _productRepository.SaveChangesAsync();

            return new SuccessResult(Messages.Added);
        }

        public async Task<IResult> Delete(DeleteProductRequest request)
        {
            var entity = await _productRepository.GetAsync(x => x.Id == request.Id);

            if (entity is null)
            {
                return new ErrorResult(Messages.Error);
            }

            await _productRepository.DeleteAsync(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<IEnumerable<GetAllProductResponse>>> GetAllProducts()
        {
            var data = await _productRepository.GetListAsync();

            var mappedData = _mapper.Map<IEnumerable<GetAllProductResponse>>(data);

            return new SuccessDataResult<IEnumerable<GetAllProductResponse>>(mappedData);
        }

        public async Task<IDataResult<IQueryable<GetAllProductResponse>>> GetAllProductsForDx()
        {
            var data = await _productRepository.GetAllProductsForDx();
            return new SuccessDataResult<IQueryable<GetAllProductResponse>>(data.ProjectTo<GetAllProductResponse>(_mapper.ConfigurationProvider));
        }

        public async Task<IResult> Update(UpdateProductRequest request)
        {
            var entity = await _productRepository.GetAsync(x => x.Id == request.Id);

            if (entity is null)
            {
                return new ErrorResult(Messages.Error);

            }

            _mapper.Map(request, entity);

            await _productRepository.UpdateAsync(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
