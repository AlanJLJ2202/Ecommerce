using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging; // Asegúrate de tener este using
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;
using TecNM.Ecommerce.WebSite.Services;

namespace TecNM.Ecommerce.WebSite.Pages.Brands;

public class Edit : PageModel
{
    [BindProperty] public BrandDto BrandDto { get; set; }
    private readonly ILogger<Edit> _logger; // Agrega un campo para el logger

    public List<string> Errors { get; set; } = new List<string>();
    
    private readonly IBrandService _service;
    
    public Edit(IBrandService service, ILogger<Edit> logger)
    {
        _service = service;
        _logger = logger; // Inicializa el logger
    }
    
    
    public async Task<IActionResult> OnGet(int? id)
    {
        
        _logger.LogInformation("OnGet method called with id: {Id}", id);

        BrandDto = new BrandDto();
        
        if(id.HasValue)
        {
            var response = await _service.GetById(id.Value);
            BrandDto = response.data;
        }


        BrandDto = new BrandDto { id = 0, Description = "" };
        
        /*if(BrandDto == null)
        {
            return RedirectToPage("/Error");
        }*/
        
        return Page();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {

        _logger.LogInformation("OnPostAsync method called with BrandDto: {BrandDto}", BrandDto);

        Errors = new List<string>();
        
        if(!ModelState.IsValid)
        {
            _logger.LogWarning("Model state is invalid.");
            return Page();
        }
        
        Response<BrandDto> response;
        if(BrandDto.id > 0)
        {
            response = await _service.UpdateAsync(BrandDto);
            _logger.LogInformation("Brand updated: {BrandDto}", BrandDto);
        }
        else
        {
            response = await _service.SaveAsync(BrandDto);
            _logger.LogInformation("Brand saved: {BrandDto}", BrandDto);
        }

        Errors = response.Errors;
        if (Errors.Count > 0)
        {
            _logger.LogError("Errors occurred: {Errors}", Errors);
            return Page();
        }

        BrandDto = response.data;
        return RedirectToPage("./List");
    }
}