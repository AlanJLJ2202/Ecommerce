using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.WebAPI.Dto;

public class ProductCategoryDto : DtoBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    
    public ProductCategoryDto()
    {
        
    }
    
    public ProductCategoryDto(ProductCategory category)
    {
        id = category.id;
        Name = category.Name;
        Description = category.Description;
    }

}