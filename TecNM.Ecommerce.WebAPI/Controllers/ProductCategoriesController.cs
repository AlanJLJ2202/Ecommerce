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
    private readonly IProductCategoryService _productCategoryService;
    
    public ProductCategoriesController(IProductCategoryService productCategoryService)
    {
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

        var response = new Response<ProductCategoryDto>();

        if (await _productCategoryService.ExistByName(categoryDto.Name, categoryDto.id))
        {
            response.Errors.Add($"Product category name {categoryDto.Name} aleready exists");
            return BadRequest(response);
        }

        // var response = new Response<ProductCategoryDto>()
        // {
        // };

        response.data = await _productCategoryService.SaveAsync(categoryDto);


        return Created($"/api/[controller]/{response.data.id}", response); 
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<ProductCategoryDto>>> GetByID(int id)
    {
        var response = new Response<ProductCategoryDto>();
        var category = await _productCategoryService.GetById(id);

        if (!await _productCategoryService.ProductCategoryExist(id))
        {
            response.Errors.Add("Category not found");
            return NotFound(response);
        }
        
        response.data = category;
        response.Message = "Category found";
        return Ok(response);
    }
    
    
    
    [HttpPut]
    public async Task<ActionResult<Response<ProductCategoryDto>>> Update([FromBody] ProductCategoryDto categoryDto)
    {
        var response = new Response<ProductCategoryDto>();
        
        if(!await _productCategoryService.ProductCategoryExist(categoryDto.id))
        {
            response.Errors.Add("Category not found");
            return NotFound(response);
        }
        
        if (await _productCategoryService.ExistByName(categoryDto.Name))
        {
            response.Errors.Add($"Product category name {categoryDto.Name} aleready exists");
            return BadRequest(response);
        }
        
        response.data = await _productCategoryService.UpdateAsync(categoryDto);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
       
         if (!await _productCategoryService.ProductCategoryExist(id))
         {
              response.Errors.Add("Category not found");
              return NotFound(response);
         }
         
         response.data = await _productCategoryService.DeleteAsync(id);
         
         return Ok(response);
    }
}


