using Dapper;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.WebAPI.DataAccess.Interfaces;
using TecNM.Ecommerce.WebAPI.Repositories.Interfaces;

namespace TecNM.Ecommerce.WebAPI.Repositories;

public class BrandRepository : IBrandRepository
{

    private readonly IDbContext _dbContext;
    private readonly List<Brand> _brands;


    public BrandRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<Brand> SaveAsync(Brand brand)
    {
        //await _dbContext.Connection.InsertAsync(category);
        //return category;
        
        
            string sql = $"INSERT INTO Brands (Name, Description, IsDeleted) VALUES ('{brand.Name}', '{brand.Description}', {brand.IsDeleted})";
    
        await _dbContext.Connection.OpenAsync();
    
        using (var command = _dbContext.Connection.CreateCommand())
        {
            command.CommandText = sql;
        
            await command.ExecuteNonQueryAsync();
        }
    
        _dbContext.Connection.Close();
    
        return brand;
    }
    
    
    public async Task<Brand> UpdateAsync(Brand brand)
    {
        string sql = $"UPDATE Brands SET Name = '{brand.Name}', Description = '{brand.Description}', IsDeleted = {brand.IsDeleted} WHERE Id = {brand.id}";
    
        await _dbContext.Connection.OpenAsync();
    
        using (var command = _dbContext.Connection.CreateCommand())
        {
            command.CommandText = sql;
        
            await command.ExecuteNonQueryAsync();
        }
    
        _dbContext.Connection.Close();

        return brand;
    }
    
    
    public async Task<List<Brand>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Brands WHERE IsDeleted = 0";
        var brands = await _dbContext.Connection.QueryAsync<Brand>(sql);
        return brands.ToList();
    }


    /*public async Task<ProductCategory> GetById(int id)
    {
        string sql = $"SELECT * FROM ProductCategory WHERE id = {id} AND IsDeleted = 0";
        
        
        //var category = await _dbContext.Connection.GetAsync<ProductCategory>(id);
        var category = await _dbContext.Connection.QueryAsync<ProductCategory>(sql);
        
        
        if (category.First() == null)
            return null;

        return category.First().isDeleted == true ? null : category.First();
    }*/
    
    public async Task<Brand> GetById(int id)
    {
        try
        {
            string sql = $"SELECT * FROM Brands WHERE id = {id} AND IsDeleted = 0";
        
            var brand = await _dbContext.Connection.QueryAsync<Brand>(sql);
        
            if (!brand.Any())
                return null;

            return brand.First().IsDeleted ? null : brand.First();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error al intentar obtener la categoría: {ex.Message}");
            return null;
        }
    }

    
    public async Task<bool> DeleteAsync(int id)
    {
        /*var category = await GetById(id);
        
        
        if (category == null)
            return false;

        category.IsDeleted = true;
        return await _dbContext.Connection.UpdateAsync(category);*/
        
        try
        {

            string sql = $"UPDATE Brands SET IsDeleted = 1 WHERE Id = {id}";
    
            
            
            await _dbContext.Connection.OpenAsync();
    
            using (var command = _dbContext.Connection.CreateCommand())
            {
                command.CommandText = sql;
        
                await command.ExecuteNonQueryAsync();
            }
    
            _dbContext.Connection.Close();

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error al intentar obtener la categoría: {ex.Message}");
            return false;
        }
    }

    public BrandRepository()
    {
        _brands = new List<Brand>();
    }
}