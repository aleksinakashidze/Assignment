using Product.Application.Common;
using Product.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface IMarketService 
    {
        Task<Result<IEnumerable<MarketDTO>>> GetAllAsync();
        Task<Result<MarketDTO>> GetByIDAsync(int id);
        Task<Result<MarketDTO>> AddAsync(MarketDTO marketDTO);
        Task<Result<bool>> UpdateAsync(MarketDTO marketDTO);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
