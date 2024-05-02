using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Ecommerce.WebAPI.Dto;

namespace TecNM.Ecommerce.WebSite.Pages.ProductCategory;

public class ListModel : PageModel
{
    public List<ProductCategoryDto> ProductCategories { get; set; }
    public string Name { get; set; }

    public ListModel()
    {
        ProductCategories = new List<ProductCategoryDto>
        {
            new ProductCategoryDto { id = 1, Name = "Primera", Description = "Test" },
            new ProductCategoryDto { id = 2, Name = "Segunda", Description = "Test" },
            new ProductCategoryDto { id = 3, Name = "Tercera", Description = "Test" }
        };
    }

    public void OnGet()
    {
        
    }
}