using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;

namespace TecNM.Ecommerce.WebSite.Services;

public interface IBrandService
{
    Task<Response<List<BrandDto>>> GetAllAsync();
    
    Task<Response<BrandDto>> GetById(int id);
    
    Task<Response<BrandDto>> SaveAsync(BrandDto brandDto);
    
    Task<Response<List<BrandDto>>> UpdateAsync(BrandDto brandDto);
    
    Task<Response<bool>> DeleteAsync(int id);
}