using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;
using TecNM.Ecommerce.WebSite.Services;

namespace TecNM.Ecommerce.WebSite.Pages.Brands;

public class Edit : PageModel
{
    [BindProperty] public BrandDto BrandDto { get; set; }

    public List<string> Errors { get; set; } = new List<string>();
    
    private readonly IBrandService _service;
    
    public Edit(IBrandService service)
    {
        _service = service;
    }
    
    
    public async Task<IActionResult> OnGet(int? id)
    {
        BrandDto = new BrandDto();
        
        if(id.HasValue)
        {
            var response = await _service.GetById(id.Value);
            BrandDto = response.data;
        }
        
        if(BrandDto == null)
        {
            return RedirectToPage("/Error");
        }
        
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if(!ModelState.IsValid)
        {
            return Page();
        }
        
        Response<BrandDto> response;
        if(BrandDto.id > 0)
        {
            response = await _service.UpdateAsync(BrandDto);
        }
        else
        {
            response = await _service.SaveAsync(BrandDto);
        }
        
        BrandDto = response.data;
        return RedirectToPage("./List");
    }
}