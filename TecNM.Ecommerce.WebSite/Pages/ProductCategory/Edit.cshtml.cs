using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Ecommerce.WebAPI.Dto;
using TecNM.Ecommerce.WebSite.Services;

namespace TecNM.Ecommerce.WebSite.Pages.ProductCategory;

public class Edit : PageModel
{
    [BindProperty] public ProductCategoryDto ProductCategoryDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();

    private readonly IProductCategoryService _service;

    public Edit(IProductCategoryService service)
    {
        _service = service;
    }

    public async Task<IActionResult> OnGet(int? id)
    {
        ProductCategoryDto = new ProductCategoryDto();
        if (id.HasValue)
        {
            //Obtener informacion del servicio API
            var response = await _service.GetById(id.Value);
            ProductCategoryDto = response.data;
        }

        if (ProductCategoryDto == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }
}