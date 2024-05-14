using Newtonsoft.Json;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;

namespace TecNM.Ecommerce.WebSite.Services;

public class BrandService : IBrandService
{
    private readonly string _baseURL = "http://localhost:5081/";
    private readonly string _endpoint = "api/Brands";
    
    public async Task<Response<List<BrandDto>>> GetAllAsync()
    {
        var url = $"{_baseURL}{_endpoint}";
        var client = new HttpClient();
        var response = await client.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var stream = await response.Content.ReadAsStreamAsync();
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();
            var responseObject = JsonConvert.DeserializeObject<Response<List<BrandDto>>>(json);
            return responseObject;
        }
        else
        {
            // Manejar el error de acuerdo a tus necesidades
            throw new HttpRequestException($"Error al obtener datos: {response.StatusCode}");
        }
    }

    public async Task<Response<BrandDto>> GetById(int id)
    {
        var url = $"{_baseURL}{_endpoint}/{id}";
        var client = new HttpClient();
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<BrandDto>>(json);
        return response;
    }

    public Task<Response<BrandDto>> SaveAsync(BrandDto brandDto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<BrandDto>>> UpdateAsync(BrandDto brandDto)
    {
        throw new NotImplementedException();
    }

    public Task<Response<bool>> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}