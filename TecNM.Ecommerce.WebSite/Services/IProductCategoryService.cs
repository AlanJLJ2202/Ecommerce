using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;

namespace TecNM.Ecommerce.WebSite.Services;

public interface IProductCategoryService
{
    Task<Response<List<ProductCategoryDto>>> GetAllAsync();
    
    Task<Response<List<ProductCategoryDto>>> GetById(int id);
    
    Task<Response<List<ProductCategoryDto>>> SaveAsync(ProductCategoryDto productCategoryDto);
    
    Task<Response<List<ProductCategoryDto>>> UpdateAsync(ProductCategoryDto productCategoryDto);

    Task<Response<bool>> DeleteAsync(int id);
}