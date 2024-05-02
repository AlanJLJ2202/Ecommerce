using Newtonsoft.Json;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Dto;

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
        var res = await client.GetAsync(url);
        var json = await res.Content.ReadAsStreamAsync();
        var response = JsonConvert.DeserializeObject<Response<List<ProductCategoryDto>>>(json);
        return response;
    }

    public Task<Response<List<ProductCategoryDto>>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<ProductCategoryDto>>> SaveAsync(ProductCategoryDto productCategoryDto)
    {
        throw new NotImplementedException();
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