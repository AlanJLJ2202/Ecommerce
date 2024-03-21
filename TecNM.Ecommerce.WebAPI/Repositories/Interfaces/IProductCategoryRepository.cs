using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.WebAPI.Repositories.Interfaces;

public interface IProductCategoryRepository
{
    Task<ProductCategory> SaveAsync(ProductCategory category);
    
    //Metodo para Actualizar las categorias de producto
    Task<ProductCategory> UpdateAsync(ProductCategory category);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<ProductCategory>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<ProductCategory> GetById(int id);
}