using EShopp.Domain.Entities;
public interface ICategoryService
{
    Task AddCategoryAsync(Category category);
    Task RemoveCategoryAsync(int id);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
}