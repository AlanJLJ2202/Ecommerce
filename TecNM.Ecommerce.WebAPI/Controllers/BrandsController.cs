using Microsoft.AspNetCore.Mvc;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;
using TecNM.Ecommerce.WebAPI.Services.Interfaces;

namespace TecNM.Ecommerce.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BrandsController : ControllerBase
{
    private readonly IBrandService _brandService;
    
    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }
    
    [HttpGet]
    public async Task<ActionResult <Response<List<Brand>>>> GetAll()
    {
        var response = new Response<List<BrandDto>>
        {
            data = await _brandService.GetAllAsync()
        };
        
        return Ok(response);
    }
    
    
    [HttpPost]
    public async Task<ActionResult<Response<BrandDto>>> Post([FromBody] BrandDto brandDto)
    {

        var response = new Response<BrandDto>()
        {
            data = await _brandService.SaveAsync(brandDto)
        };

        return Created($"/api/[controller]/{response.data.id}", response); 
    }
    
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<BrandDto>>> GetByID(int id)
    {
        var response = new Response<BrandDto>();
        var brand = await _brandService.GetById(id);

        if (!await _brandService.BrandExist(id))
        {
            response.Errors.Add("Brand not found");
            return NotFound(response);
        }
        
        response.data = brand;
        response.Message = "Brand found";
        return Ok(response);
    }

    [HttpPut]
    public async Task<ActionResult<Response<BrandDto>>> Update([FromBody] BrandDto brandDto)
    {
        var response = new Response<BrandDto>();

        if (!await _brandService.BrandExist(brandDto.id))
        {
            response.Errors.Add("Brand not found");
            return NotFound(response);
        }

        response.data = await _brandService.UpdateAsync(brandDto);
        return Ok(response);
    }
    
    
    [HttpDelete]
    public async Task<ActionResult<Response<bool>>> Delete(int id)
    {
        var response = new Response<bool>();
        
        if (!await _brandService.BrandExist(id))
        {
            response.Errors.Add("Brand not found");
            return NotFound(response);
        }
        
        response.data = await _brandService.DeleteAsync(id);
        return Ok(response);
    }
    
}

