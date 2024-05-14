using Newtonsoft.Json;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;
using StringContent = System.Net.Http.StringContent;

namespace TecNM.Ecommerce.WebSite.Services;

public class ProductCategoryService : IProductCategoryService
{

    private readonly string _baseURL = "http://localhost:5081/";
    private readonly string _endpoint = "api/productcategories";

    public ProductCategoryService()
    {
        
    }

    public async Task<Response<List<ProductCategoryDto>>> GetAllAsync()
    {
        var url = $"{_baseURL}{_endpoint}";
        var client = new HttpClient();
        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();
            var responseObject = JsonConvert.DeserializeObject<Response<List<ProductCategoryDto>>>(json);
            return responseObject;
        }
        else
        {
            // Manejar el error de acuerdo a tus necesidades
            throw new HttpRequestException($"Error al obtener datos: {response.StatusCode}");
        }
    }

    public async Task<Response<ProductCategoryDto>> GetById(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<ProductCategoryDto>>(json);
        return response;
    }

    public async Task<Response<ProductCategoryDto>> SaveAsync(ProductCategoryDto productCategoryDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(productCategoryDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<ProductCategoryDto>>(json);
        
        return response;
    }

    public Task<Response<List<ProductCategoryDto>>> UpdateAsync(ProductCategoryDto productCategoryDto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}