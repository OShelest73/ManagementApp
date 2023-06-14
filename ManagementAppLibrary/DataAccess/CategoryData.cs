using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAppLibrary.DataAccess;

public class CategoryData : ICategoryData
{
    private readonly ISqlDataAccess _db;

    public CategoryData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<List<CategoryModel>> GetAllCategories()
    {
        string sql = "select * from dbo.Categories";

        return _db.LoadData<CategoryModel, dynamic>(sql, new { });
    }

    public Task<CategoryModel> FindCategory(string id)
    {
        string sql = "select * from dbo.Categories where CategoryName = @id";

        return _db.FindElement<CategoryModel, dynamic>(sql, new { id });
    }

    public Task InsertCategory(CategoryModel category)
    {
        string sql = @"insert into dbo.Categories (CategoryName) values (@CategoryName)";
        return _db.SaveData(sql, category);
    }
}
