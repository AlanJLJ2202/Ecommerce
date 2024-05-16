using TecNM.Ecommerce.WebAPI.Dto;

namespace TecNM.Ecommerce.WebAPI.Services.Interfaces;

public interface IBrandService
{
    Task<bool> BrandExist(int id);
    
    Task<BrandDto> SaveAsync(BrandDto category);
    
    //Metodo para Actualizar las categorias de producto
    Task<BrandDto> UpdateAsync(BrandDto category);
    
    //Metodo para retornar una lista de categorias de producto
    Task<List<BrandDto>> GetAllAsync();
    
    //Metodo para retornar el id de las categorias del producto que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una categoria por id
    Task<BrandDto?> GetById(int id);

    Task<bool> ExistByName(string name, int id = 0);
}