using Microsoft.AspNetCore.Mvc;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;
using TecNM.Ecommerce.WebAPI.Repositories;
using TecNM.Ecommerce.WebAPI.Repositories.Interfaces;

namespace TecNM.Ecommerce.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductCategoriesController : ControllerBase
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    
    public ProductCategoriesController(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }
    
    [HttpGet]
    public  async Task<ActionResult <Response<List<ProductCategory>>>> GetAll()
    {
        var categories = await _productCategoryRepository.GetAllAsync();
        var response = new Response<List<ProductCategory>>();
        response.data = categories;

        return Ok(response);
    }
    
    
    [HttpPost]
    public async Task<ActionResult<Response<ProductCategory>>> Post([FromBody] ProductCategory category)
    {
        
        category = await _productCategoryRepository.SaveAsync(category);

        var response = new Response<ProductCategory>();
        response.data = category;

        return Created($"/api/[controller]/{category.id}", response);
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategory>>> GetByID(int id)
    {
        var response = new Response<ProductCategory>();

        var category = await _productCategoryRepository.GetById(id);
        response.data = category;
        
        if (category == null)
        {
            response.Errors.Add("Category not found");
            return NotFound(response);
        }

        //var categoryDto = new ProductCategoryDto(category);
        //response.data = categoryDto;
        
        response.Message = "Category found";
        return Ok(response);
    }
    
    
    
    [HttpPut]
    public async Task<ActionResult<Response<ProductCategory>>> Update([FromBody] ProductCategory category)
    {
        /*var category = await _productCategoryRepository.GetById(id);
        var response = new Response<ProductCategory>();

        if (category == null)
        {
            response.Errors.Add("Category not found");
            return NotFound(response);
        }*/
        
        var category_update = await _productCategoryRepository.UpdateAsync(category);
        var response = new Response<ProductCategory>{ data = category_update};
        response.Message = "Category found";
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


