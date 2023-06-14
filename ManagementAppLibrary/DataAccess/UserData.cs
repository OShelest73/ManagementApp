using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAppLibrary.DataAccess;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<List<UserModel>> GetUsersInformation()
    {
        string sql = "select EmailAdress, FirstName, LastName, Category, TaskId from dbo.Users";

        return _db.LoadData<UserModel, dynamic>(sql, new { });
    }

    public Task<List<UserModel>> GetAppointedUsers(int taskId)
    {
        string sql = "select EmailAdress, FirstName, LastName from dbo.Users where TaskId = @taskId";

        return _db.LoadData<UserModel, dynamic>(sql, new { taskId });
    }

    public Task<List<UserModel>> GetUsersToAppoint(string category)
    {
        string sql = "select EmailAdress, FirstName, LastName from dbo.Users where (TaskId is NULL) and (Category = @category)";

        return _db.LoadData<UserModel, dynamic>(sql, new { category });
    }

    public Task<UserModel> FindUserInformation(string id)
    {
        string sql = "select EmailAdress, FirstName, LastName, Category, TaskId from dbo.Users where EmailAdress = @id";

        return _db.FindElement<UserModel, dynamic>(sql, new { id });
    }

    public Task<UserModel> FindUserAccount(string id)
    {
        string sql = "select EmailAdress, Password, Salt from dbo.Users where EmailAdress = @id";

        return _db.FindElement<UserModel, dynamic>(sql, new { id });
    }

    public Task AppointUser(string userId, int taskId)
    {
        string sql = @"update dbo.Users set TaskId = @taskId where EmailAdress = @userId";
        return _db.SaveData(sql, new { userId, taskId });
    }

    public Task RemoveFromUser(string userId)
    {
        string sql = @"update dbo.Users set TaskId = NULL where EmailAdress = userId";
        return _db.SaveData(sql, new { userId });
    }

    public Task RemoveTaskFromUsers(int taskId)
    {
        string sql = @"update dbo.Users set TaskId = NULL where TaskId = @taskId";
        return _db.SaveData(sql, new { taskId });
    }

    public Task CreateUser(UserModel user)
    {
        string sql = @"insert into dbo.Users (FirstName, LastName, EmailAdress, Password, Salt, Category)
                        values (@FirstName, @LastName, @EmailAdress, @Password, @Salt, @Category)";
        return _db.SaveData(sql, user);
    }

    public Task ChangePassword(UserModel user)
    {
        string sql = @"update dbo.Users set Salt = @Salt, Password = @Password where EmailAdress = @EmailAdress";
        return _db.SaveData(sql, user);
    }
}
