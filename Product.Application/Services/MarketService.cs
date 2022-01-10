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
    public class MarketService:IMarketService
    {
        private readonly IMarketRepository _marketRepository;
        private readonly IPriceRepository _priceRepository;

        public MarketService(IMarketRepository marketRepository, IPriceRepository priceRepository)
        {
            _marketRepository = marketRepository;
            _priceRepository = priceRepository;
        }

        public async Task<Result<MarketDTO>> GetByIDAsync(int marketID)
        {
            try
            {
                var resultFromDb = await _marketRepository.GetByIdAsync(marketID);

                var result = MapperConfig.Mapper.Map<MarketDTO>(resultFromDb);

                return new Result<MarketDTO> { Ok = true, Response = result };
            }
            catch (Exception ex)
            {
                return new Result<MarketDTO> { Ok = false, ExceptionMessage = ex.Message };
            }
        }

        public async Task<Result<MarketDTO>> AddAsync(MarketDTO marketDTO)
        {
            if (marketDTO == null)
                return new Result<MarketDTO> { Ok = false, ExceptionMessage = "Value Cannot be Null" };
            
            try
            {
                var result = await _marketRepository.AddAsync(MapperConfig.Mapper.Map<MarketEntity>(marketDTO));

                return new Result<MarketDTO> { Ok = true, Response = MapperConfig.Mapper.Map<MarketDTO>(result) };
            }
            catch (Exception ex)
            {
                return new Result<MarketDTO> { Ok = false, ExceptionMessage = ex.Message };
            }
        }

        public async Task<Result<IEnumerable<MarketDTO>>> GetAllAsync()
        {
            try
            {
                var market = await _marketRepository.GetAllAsync();

                var result = MapperConfig.Mapper.Map<IEnumerable<MarketEntity>, IEnumerable<MarketDTO>>(market);

                return new Result<IEnumerable<MarketDTO>> { Ok = true, Response = result };
            }
            catch (Exception ex)
            {
                return new Result<IEnumerable<MarketDTO>> { Ok = false, ExceptionMessage = ex.Message };
            }
        }

        public async Task<Result<bool>> UpdateAsync(MarketDTO marketDTO)
        {
            if (marketDTO == null)
                return new Result<bool> { Ok = false, ExceptionMessage = "Value Cannot be Null" };
            try
            {
                await _marketRepository.UpdateAsync(MapperConfig.Mapper.Map<MarketEntity>(marketDTO));

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
                await _marketRepository.DeleteAsync(id);
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
                //getting price by market ID
                var Prices = await _priceRepository.GetByMarketID(id);
                if (Prices.Count()!=0)
                    await _priceRepository.DeleteWithRangeAsync(Prices);

                return new Result<bool> { Ok = true, Response = true };
            }
            catch (Exception ex)
            {
                return new Result<bool> { Ok = false, ExceptionMessage = ex.Message };
            }


        }
    }
}
