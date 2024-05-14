using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Ecommerce.WebAPI.Dto;
using TecNM.Ecommerce.WebSite.Services;

namespace TecNM.Ecommerce.WebSite.Pages.Brands;

public class Edit : PageModel
{
    [BindProperty] public BrandDto Brand { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    
    private readonly IBrandService _service;
    
    public Edit(IBrandService service)
    {
        _service = service;
    }
    
    
    public async Task<IActionResult> OnGet(int? id)
    {
        Brand = new BrandDto();
        
        if(id.HasValue)
        {
            var response = await _service.GetById(id.Value);
            Brand = response.data;
        }
        
        if(Brand == null)
        {
            return RedirectToPage("/Error");
        }
        
        return Page();
    }
}