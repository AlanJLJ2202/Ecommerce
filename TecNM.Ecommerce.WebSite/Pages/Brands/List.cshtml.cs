using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.WebAPI.Dto;
using TecNM.Ecommerce.WebSite.Services;

namespace TecNM.Ecommerce.WebSite.Pages.Brands;

public class ListModel : PageModel
{
    private readonly IBrandService _service;
    public List<BrandDto> Brands { get; set; }
    public string Name { get; set; }

    public ListModel(IBrandService service)
    {
        _service = service;
        Brands = new List<BrandDto>();
    }
    
    
    public async Task<IActionResult> OnGet()
    {
        var response = await _service.GetAllAsync();
        Brands = response.data;
        return Page();
    }
}