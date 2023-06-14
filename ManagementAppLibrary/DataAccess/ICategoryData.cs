namespace ManagementAppLibrary.DataAccess
{
    public interface ICategoryData
    {
        Task<CategoryModel> FindCategory(string id);
        Task<List<CategoryModel>> GetAllCategories();
        Task InsertCategory(CategoryModel category);
    }
}