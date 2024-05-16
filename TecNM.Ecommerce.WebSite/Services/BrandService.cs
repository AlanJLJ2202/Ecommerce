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

    public async Task<Response<BrandDto>> SaveAsync(BrandDto brandDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(brandDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PostAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<BrandDto>>(json);

        return response;
    }

    public async Task<Response<BrandDto>> UpdateAsync(BrandDto brandDto)
    {
        var url = $"{_baseURL}{_endpoint}";
        var jsonRequest = JsonConvert.SerializeObject(brandDto);
        var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
        var client = new HttpClient();
        var res = await client.PutAsync(url, content);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<BrandDto>>(json);

        return response;
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var url = $"{_baseURL}{_endpoint}?id={id}";
        Console.WriteLine(url);
        var client = new HttpClient();
        var res = await client.DeleteAsync(url);
        var json = await res.Content.ReadAsStringAsync();

        var response = JsonConvert.DeserializeObject<Response<bool>>(json);

        return response;
    }
}