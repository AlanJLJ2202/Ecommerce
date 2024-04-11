using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;
using TecNM.Ecommerce.WebAPI.Repositories.Interfaces;
using TecNM.Ecommerce.WebAPI.Services.Interfaces;

namespace TecNM.Ecommerce.WebAPI.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;
    
    public BrandService( IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }
   
    

    public async Task<bool> BrandExist(int id)
    {
        var brand = await _brandRepository.GetById(id);
        return (brand != null);
    }

    public async Task<BrandDto> SaveAsync(BrandDto brandDto)
    {
        var brand = new Brand
        {
            Name = brandDto.Name,
            Description = brandDto.Description,
            CreatedBy = "",
            CreatedDate = DateTime.Now,
            UpdatedBy = "",
            UpdateDate = DateTime.Now
        };
        
        brand = await _brandRepository.SaveAsync(brand);
        brandDto.id = brand.id;

        return brandDto;
    }

    public async Task<BrandDto> UpdateAsync(BrandDto brandDto)
    {
        var response = new Response<Brand>();
        var brand = await _brandRepository.GetById(brandDto.id);

        if (brand == null)
            throw new Exception("brand not found");
            
        brand.Name = brandDto.Name;
        brand.Description = brandDto.Description;
        brand.UpdatedBy = "";
        brand.UpdateDate = DateTime.Now;
        
        await _brandRepository.UpdateAsync(brand);

        return brandDto;
    }

    public async Task<List<BrandDto>> GetAllAsync()
    {
        
        var brands = await _brandRepository.GetAllAsync();
        
        var brandsDto = brands.Select(c => new BrandDto(c)).ToList();
        

        return brandsDto;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _brandRepository.DeleteAsync(id);
    }

    public async Task<BrandDto?> GetById(int id)
    {
        var brand = await _brandRepository.GetById(id);
        if (brand == null)
        {
            return null;
        }

        var brandDto = new BrandDto(brand);
        return brandDto;
    }
}