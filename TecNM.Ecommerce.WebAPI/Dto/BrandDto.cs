using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.WebAPI.Dto;

public class BrandDto : DtoBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public BrandDto()
    {
        
    }
    public BrandDto(Brand brand)
    {
        id = brand.id;
        Name = brand.Name;
        Description = brand.Description;
    }

}

