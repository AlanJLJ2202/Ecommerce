using TecNM.Ecommerce.Core.Entities;

namespace TecNM.Ecommerce.WebAPI.Repositories.Interfaces;

public interface IBrandRepository
{
    Task<Brand> SaveAsync(Brand brand);
    
    //Metodo para Actualizar las marcas
    Task<Brand> UpdateAsync(Brand brand);
    
    //Metodo para retornar una lista de marcas
    Task<List<Brand>> GetAllAsync();
    
    //Metodo para retornar el id de las marcas que se borrará
    Task<bool> DeleteAsync(int id);
    
    //Metodo para obtener una marca por id
    Task<Brand?> GetById(int id);


    Task<Brand> GetByName(string name, int id = 0);
}

