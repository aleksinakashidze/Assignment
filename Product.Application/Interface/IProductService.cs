using Product.Application.Common;
using Product.Application.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Application.Interface
{
    public interface IProductService
    {
        Task<Result<IEnumerable<ProductDTO>>> GetAllAsync();
        Task<Result<ProductDTO>> GetByIDAsync(int ProductID);
        Task<Result<ProductDTO>> CheckByIDAsync(int ProductID);
        Task<Result<ProductDTO>> AddAsync(ProductDTO productDTO);
        Task<Result<bool>> UpdateAsync(ProductDTO productDTO);
        Task<Result<bool>> DeleteAsync(int ProductID);

    }
}
