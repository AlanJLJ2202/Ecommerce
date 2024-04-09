using Microsoft.AspNetCore.Mvc;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;
using TecNM.Ecommerce.WebAPI.Repositories.Interfaces;
using TecNM.Ecommerce.WebAPI.Services.Interfaces;

namespace TecNM.Ecommerce.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductCategoriesController : ControllerBase
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly IProductCategoryService _productCategoryService;
    
    public ProductCategoriesController(IProductCategoryRepository productCategoryRepository, IProductCategoryService productCategoryService)
    {
        _productCategoryRepository = productCategoryRepository;
        _productCategoryService = productCategoryService;
    }
    
    [HttpGet]
    public  async Task<ActionResult <Response<List<ProductCategory>>>> GetAll()
    {
        var response = new Response<List<ProductCategoryDto>>
        {
            data = await _productCategoryService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    
    [HttpPost]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Post([FromBody] ProductCategoryDto categoryDto)
    {
        
        //category = await _productCategoryRepository.SaveAsync(category);
        
        var response = new Response<ProductCategoryDto>();
        var category = new ProductCategory
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };

        //var response = new Response<ProductCategory>();
        //response.data = category;
        
        category = await _productCategoryRepository.SaveAsync(category);
        categoryDto.id = category.id;
        response.data = categoryDto;

        return Created($"/api/[controller]/{category.id}", response);
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategoryDto>>> GetByID(int id)
    {
        var response = new Response<ProductCategoryDto>();
        var category = await _productCategoryService.GetById(id);
        
        
        if (category == null)
        {
            response.Errors.Add("Category not found");
            return NotFound(response);
        }

        //var categoryDto = new ProductCategoryDto(category);
        //response.data = categoryDto;
        
        response.data = category;

        response.Message = "Category found";
        return Ok(response);
    }
    
    
    
    [HttpPut]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Update([FromBody] ProductCategoryDto categoryDto)
    {
        var response = new Response<ProductCategory>();
        var category = await _productCategoryRepository.GetById(categoryDto.id);

        if (category == null)
        {
            response.Errors.Add("Product category not found");
            return NotFound(response);
        }

        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;
        category.UpdatedBy = "";
        category.UpdateDate = DateTime.Now;
        
        await _productCategoryRepository.UpdateAsync(category);
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _productCategoryRepository.DeleteAsync(id);
        response.data = result;
        return Ok(response);
    }
}


