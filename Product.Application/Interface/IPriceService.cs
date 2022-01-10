using Product.Application.Common;
using Product.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface IPriceService
    {
        Task<Result<IEnumerable<PriceDTO>>> GetAllAsync();
        Task<Result<PriceDTO>> GetByIDAsync(int id);
        Task<Result<PriceDTO>> AddAsync(PriceDTO priceDTO);
        Task<Result<bool>> UpdateAsync(PriceDTO priceDTO);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
