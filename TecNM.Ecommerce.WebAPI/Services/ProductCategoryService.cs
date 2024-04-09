using TecNM.Ecommerce.WebAPI.Dto;
using TecNM.Ecommerce.WebAPI.Repositories.Interfaces;
using TecNM.Ecommerce.WebAPI.Services;
using TecNM.Ecommerce.WebAPI.Services.Interfaces;

namespace TecNM.Ecommerce.WebAPI.Services;

public class ProductCategoryService : IProductCategoryService
{

    private readonly IProductCategoryRepository _productCategoryRepository;

    // public ProductCategoryService(
    //         IProductCategoryRepository productCategoryRepository, 
    //         IProductCategoryService productCategoryService
    //     )
    // {
    //     _productCategoryRepository = productCategoryRepository;
    //     _productCategoryService = productCategoryService;
    // }
    
    public ProductCategoryService( IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    

    public async Task<bool> ProductCategoryExist(int id)
    {
        var category = await _productCategoryRepository.GetById(id);
        return (category != null);
    }

    public Task<ProductCategoryDto> SaveAsync(ProductCategoryDto category)
    {
        throw new NotImplementedException();
    }

    public Task<ProductCategoryDto> UpdateAsync(ProductCategoryDto category)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductCategoryDto>> GetAllAsync()
    {
        
        var categories = await _productCategoryRepository.GetAllAsync();
        
        var categoriesDto = categories.Select(c => new ProductCategoryDto(c)).ToList();
        

        return categoriesDto;
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductCategoryDto> GetById(int id)
    {
        var category = await _productCategoryRepository.GetById(id);
        if (category == null)
        {
            throw new Exception("Product category not found");
        }

        var categoryDto = new ProductCategoryDto(category);
        return categoryDto;
    }
}