using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;
using TecNM.Ecommerce.WebAPI.Repositories.Interfaces;
using TecNM.Ecommerce.WebAPI.Services;
using TecNM.Ecommerce.WebAPI.Services.Interfaces;

namespace TecNM.Ecommerce.WebAPI.Services;



public class ProductCategoryService : IProductCategoryService
{

    private readonly IProductCategoryRepository _productCategoryRepository;
    
    public ProductCategoryService( IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    

    public async Task<bool> ProductCategoryExist(int id)
    {
        var category = await _productCategoryRepository.GetById(id);
        return (category != null);
    }

    public async Task<ProductCategoryDto> SaveAsync(ProductCategoryDto categoryDto)
    {
        var category = new ProductCategory
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };
        
        category = await _productCategoryRepository.SaveAsync(category);
        categoryDto.id = category.id;

        return categoryDto;
    }

    public async Task<ProductCategoryDto> UpdateAsync(ProductCategoryDto categoryDto)
    {
        var response = new Response<ProductCategory>();
        var category = await _productCategoryRepository.GetById(categoryDto.id);

        if (category == null)
            throw new Exception("Category not found");
            
        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;
        category.UpdatedBy = "";
        category.UpdateDate = DateTime.Now;
        
        await _productCategoryRepository.UpdateAsync(category);

        return categoryDto;
    }

    public async Task<List<ProductCategoryDto>> GetAllAsync()
    {
        
        var categories = await _productCategoryRepository.GetAllAsync();
        
        var categoriesDto = categories.Select(c => new ProductCategoryDto(c)).ToList();
        

        return categoriesDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _productCategoryRepository.DeleteAsync(id);
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
    
    public async Task<bool> ExistByName(string name, int id = 0)
    {
        var category = await _productCategoryRepository.GetByName(name, id);
        return category != null;
    }
    
}