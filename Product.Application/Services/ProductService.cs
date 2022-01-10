using Product.Application.Common;
using Product.Application.DTO;
using Product.Application.Interface;
using Product.Application.Mapper;
using Product.Core.Entities;
using Product.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Services
{
   public  class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPriceRepository _priceRepository;

        public ProductService(IProductRepository productRepository, IPriceRepository priceRepository)
        {
            _productRepository = productRepository;
            _priceRepository = priceRepository;
        }
        
        public async Task<Result<ProductDTO>> GetByIDAsync(int ProductID)
        {
            try
            {
                var resultFromDb = await _productRepository.GetByIdAsync(ProductID);

                var result = MapperConfig.Mapper.Map<ProductDTO>(resultFromDb);

                return new Result<ProductDTO> { Ok = true, Response = result };
            }
            catch (Exception ex)
            {
                return new Result<ProductDTO> { Ok = false, ExceptionMessage = ex.Message };
            }
        }

        public async Task<Result<ProductDTO>> CheckByIDAsync(int ProductID)
        {
            try
            {
                var resultFromDb = await _productRepository.CheckByIDAsync(ProductID);

                var result = MapperConfig.Mapper.Map<ProductDTO>(resultFromDb);

                return new Result<ProductDTO> { Ok = true, Response = result };
            }
            catch (Exception ex)
            {
                return new Result<ProductDTO> { Ok = false, ExceptionMessage = ex.Message };
            }
        }

        public async Task<Result<ProductDTO>> AddAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return new Result<ProductDTO> { Ok = false, ExceptionMessage = "Value Cannot be Null" };

            try
            {
                var result = await _productRepository.AddAsync(MapperConfig.Mapper.Map<ProductEntity>(productDTO));

                return new Result<ProductDTO> { Ok = true, Response = MapperConfig.Mapper.Map<ProductDTO>(result)};
            }
            catch (Exception ex)
            {
                return new Result<ProductDTO> { Ok = false, ExceptionMessage = ex.Message };
            }
        }

        public async Task<Result<IEnumerable<ProductDTO>>> GetAllAsync()
        {
            try
            {
                var product = await _productRepository.GetAllAsync();

                var result = MapperConfig.Mapper.Map<IEnumerable<ProductEntity>, IEnumerable<ProductDTO>>(product);

                return new Result<IEnumerable<ProductDTO>> { Ok = true, Response = result };
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<ProductDTO>> { Ok = false, ExceptionMessage = ex.Message };
            }
        }

        public async Task<Result<bool>> UpdateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return new Result<bool> { Ok = false, ExceptionMessage = "Value Cannot be Null" };
            try
            {
                await _productRepository.UpdateAsync(MapperConfig.Mapper.Map<ProductEntity>(productDTO));

                return new Result<bool> { Ok = true, Response = true };
            }
            catch (Exception ex)
            {
                return new Result<bool> { Ok = false, ExceptionMessage = ex.Message };
            }
        }

        public async Task<Result<bool>> DeleteAsync(int id)
        {
            try
            {
               
                await _productRepository.DeleteAsync(id);
                await DeleteToBackAsync(id);
                return new Result<bool> { Ok = true, Response = true };
            }
            catch (Exception ex)
            {
                return new Result<bool> { Ok = false, ExceptionMessage = ex.Message };
            }


        }

        private async Task<Result<bool>> DeleteToBackAsync(int id)
        {

            try
            {
                var result = await _priceRepository.GetByProductID(id);
                if(result.Count() != 0)
                await _priceRepository.DeleteWithRangeAsync(result);

                return new Result<bool> { Ok = true, Response = true };
            }
            catch (Exception ex)
            {
                return new Result<bool> { Ok = false, ExceptionMessage = ex.Message };
            }


        }

    }
}
