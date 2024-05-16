using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.WebAPI.Dto;

namespace TecNM.Ecommerce.WebAPI.Services.Interfaces;

public interface IProductCategoryService
{
    Task<bool> ProductCategoryExist(int id);
    
    Task<ProductCategoryDto> SaveAsync(ProductCategoryDto category);
    
    //Metodo para Actualizar las categorias de producto
    Task<ProductCategoryDto> UpdateAsync(ProductCategoryDto category);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<ProductCategoryDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<ProductCategoryDto> GetById(int id);
    
    Task<bool> ExistByName(string name, int id = 0);
}