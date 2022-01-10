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
    public class PriceService:IPriceService
    {
        private readonly IPriceRepository _priceRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMarketRepository _marketRepository;

        public PriceService(IPriceRepository priceRepository, IProductRepository productRepository, IMarketRepository marketRepository)
        {
            _priceRepository = priceRepository;
            _productRepository = productRepository;
            _marketRepository = marketRepository;
        }

        public async Task<Result<PriceDTO>> GetByIDAsync(int priceID)
        {
            try
            {

                var resultFromDb = await _priceRepository.GetByIdAsync(priceID);

                var result = MapperConfig.Mapper.Map<PriceDTO>(resultFromDb);

                return new Result<PriceDTO> { Ok = true, Response = result };
            }
            catch (Exception ex)
            {
                return new Result<PriceDTO> { Ok = false, ExceptionMessage = ex.Message };
            }
        }

        public async Task<Result<PriceDTO>> AddAsync(PriceDTO priceDTO)
        {
            if (priceDTO == null)
                return new Result<PriceDTO> { Ok = false, ExceptionMessage = "Value Cannot be Null" };

            try
            {
                var result = await _priceRepository.AddAsync(MapperConfig.Mapper.Map<PriceEntity>(priceDTO));

                return new Result<PriceDTO> { Ok = true, Response = MapperConfig.Mapper.Map<PriceDTO>(result) };
            }
            catch (Exception ex)
            {
                return new Result<PriceDTO> { Ok = false, ExceptionMessage = ex.Message };
            }
        }

        public async Task<Result<IEnumerable<PriceDTO>>> GetAllAsync()
        {
            List<PriceResponse> priceResponces = new List<PriceResponse>();
            try
            {
                var prices = await _priceRepository.GetAllAsync();

                var result = MapperConfig.Mapper.Map<IEnumerable<PriceEntity>, IEnumerable<PriceDTO>>(prices);

                return new Result<IEnumerable<PriceDTO>> { Ok = true, Response = result };
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<PriceDTO>> { Ok = false, ExceptionMessage = ex.Message };
            }
        }

        public async Task<Result<bool>> UpdateAsync(PriceDTO priceDTO)
        {
            if (priceDTO == null)
                return new Result<bool> { Ok = false, ExceptionMessage = "Value Cannot be Null" };
            try
            {
                await _priceRepository.UpdateAsync(MapperConfig.Mapper.Map<PriceEntity>(priceDTO));

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
                await _priceRepository.DeleteAsync(id);

                return new Result<bool> { Ok = true, Response = true };
            }
            catch (Exception ex)
            {
                return new Result<bool> { Ok = false, ExceptionMessage = ex.Message };
            }
        }
    }
}
