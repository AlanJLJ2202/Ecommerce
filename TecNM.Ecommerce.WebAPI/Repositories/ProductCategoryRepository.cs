using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TecNM.Ecommerce.Core.Entities;
using TecNM.Ecommerce.Core.Http;
using TecNM.Ecommerce.WebAPI.Controllers;
using TecNM.Ecommerce.WebAPI.DataAccess.Interfaces;
using TecNM.Ecommerce.WebAPI.Repositories.Interfaces;

namespace TecNM.Ecommerce.WebAPI.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{

    private readonly IDbContext _dbContext;
    private readonly List<ProductCategory> _categories;


    public ProductCategoryRepository(IDbContext context)
    {
        _dbContext = context;
    }

    public async Task<ProductCategory> SaveAsync(ProductCategory category)
    {
        //await _dbContext.Connection.InsertAsync(category);
        //return category;
        
        
        string sql = $"INSERT INTO ProductCategory (Name, Description, IsDeleted) VALUES ('{category.Name}', '{category.Description}', {category.IsDeleted})";
    
        await _dbContext.Connection.OpenAsync();
    
        using (var command = _dbContext.Connection.CreateCommand())
        {
            command.CommandText = sql;
        
            await command.ExecuteNonQueryAsync();
        }
    
        _dbContext.Connection.Close();
    
        return category;
    }
    
    
    public async Task<ProductCategory> UpdateAsync(ProductCategory category)
    {
        string sql = $"UPDATE ProductCategory SET Name = '{category.Name}', Description = '{category.Description}', IsDeleted = {category.IsDeleted} WHERE Id = {category.id}";
    
        await _dbContext.Connection.OpenAsync();
    
        using (var command = _dbContext.Connection.CreateCommand())
        {
            command.CommandText = sql;
        
            await command.ExecuteNonQueryAsync();
        }
    
        _dbContext.Connection.Close();

        return category;
    }
    
    
    public async Task<List<ProductCategory>> GetAllAsync()
    {
        const string sql = "SELECT * FROM ProductCategory WHERE IsDeleted = 0";
        var categories = await _dbContext.Connection.QueryAsync<ProductCategory>(sql);
        return categories.ToList();
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
    
    public async Task<ProductCategory> GetById(int id)
    {
        try
        {
            string sql = $"SELECT * FROM ProductCategory WHERE id = {id} AND IsDeleted = 0";
        
            var category = await _dbContext.Connection.QueryAsync<ProductCategory>(sql);
        
            if (!category.Any())
                return null;

            return category.First().IsDeleted ? null : category.First();
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

            string sql = $"UPDATE ProductCategory SET IsDeleted = 1 WHERE Id = {id}";
    
            
            
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






    public ProductCategoryRepository()
    {
        _categories = new List<ProductCategory>();
    }

   
    

    

    

    
}