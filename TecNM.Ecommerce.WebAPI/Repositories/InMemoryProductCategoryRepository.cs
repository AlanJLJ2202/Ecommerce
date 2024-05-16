// using TecNM.Ecommerce.Core.Entities;
// using TecNM.Ecommerce.WebAPI.Repositories.Interfaces;
//
// namespace TecNM.Ecommerce.WebAPI.Repositories;
//
// public class InMemoryProductCategoryRepository : IProductCategoryRepository
// {
//     /*public ProductCategoryRepository(IProductCategoryRepository productCategoryRepository)
//     {
//         _productCategoryRepository = productCategoryRepository;
//     }*/
//
//     private readonly List<ProductCategory> _categories;
//
//     /*public ProductCategoryRepository()
//     {
//         _categories = new List<ProductCategory>();
//     }*/
//
//     public Task<ProductCategory> SaveAsync(ProductCategory category)
//     {
//         throw new NotImplementedException();
//     }
//
//     public async Task<ProductCategory> UpdateAsync(ProductCategory category)
//     {
//         var index = _categories.FindIndex(x => x.id == category.id);
//         if (index != -1)
//             _categories[index] = category;
//         return await Task.FromResult(category);
//     }
//
//     public async Task<List<ProductCategory>> GetAllAsync()
//     {
//         throw new NotImplementedException();
//     }
//
//     public async Task<bool> DeleteAsync(int id)
//     {
//         _categories.RemoveAll(x => x.id == id);
//         return true;
//     }
//
//     public async Task<ProductCategory> GetById(int id)
//     {
//         var category = _categories.FirstOrDefault(x => x.id == id);
//         return await Task.FromResult(category);
//     }
//     
//     
//     
//     
// }