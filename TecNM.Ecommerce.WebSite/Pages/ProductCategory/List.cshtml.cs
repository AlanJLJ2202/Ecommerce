using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Ecommerce.Core.Http;
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


    /*public async Task<IActionResult> onPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Response<ProductCategoryDto> response;
        if (ProductCategoryDto.id > 0)
        {
            response = await _service.UpdateAsync(ProductCategoryDto);
        }
        else
        {
            response = await _service.SaveAsync(ProductCategoryDto);
        }

        ProductCategoryDto = response.data;
        return RedirectToPage("./List");
    }*/
}