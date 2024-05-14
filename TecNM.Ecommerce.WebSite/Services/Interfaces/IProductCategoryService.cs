using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;

namespace TecNM.Ecommerce.WebSite.Services;

public interface IProductCategoryService
{
    Task<Response<List<ProductCategoryDto>>> GetAllAsync();
    
    Task<Response<ProductCategoryDto>> GetById(int id);
    
    Task<Response<ProductCategoryDto>> SaveAsync(ProductCategoryDto productCategoryDto);
    
    Task<Response<List<ProductCategoryDto>>> UpdateAsync(ProductCategoryDto productCategoryDto);

    Task<Response<bool>> DeleteAsync(int id);
}