using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Ecommerce.WebAPI.Dto;
using TecNM.Ecommerce.WebSite.Services;

namespace TecNM.Ecommerce.WebSite.Pages.Brands;

public class Delete : PageModel
{
    [BindProperty] public BrandDto Brand { get; set; }
    
    public List<string> Errors { get; set; } = new List<string>();
    
    private readonly IBrandService _service;
    
    public Delete(IBrandService service)
    {
        _service = service;
    }
    
    public async Task<IActionResult> OnGet(int id)
    {
        Brand = new BrandDto();

        //Obtener informacion
        var response = await _service.GetById(id);
        Brand = response.data;

        if (Brand == null)
        {
            return RedirectToPage("/Error");
        }

        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _service.DeleteAsync(Brand.id);
        return RedirectToPage("./List");
    }
}