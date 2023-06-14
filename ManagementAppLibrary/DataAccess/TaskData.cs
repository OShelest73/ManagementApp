using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAppLibrary.DataAccess;

public class TaskData : ITaskData
{
    private readonly ISqlDataAccess _db;

    public TaskData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<List<TaskModel>> GetTasks()
    {
        string sql = "select * from dbo.Tasks where Archived = 0";

        return _db.LoadData<TaskModel, dynamic>(sql, new { });
    }

    public Task<List<TaskModel>> GetArchivedTasks()
    {
        string sql = "select * from dbo.Tasks where Archived = 1";

        return _db.LoadData<TaskModel, dynamic>(sql, new { });
    }

    public Task<TaskModel> GetTask(int id)
    {
        string sql = "select * from dbo.Tasks where Id = @id";

        return _db.FindElement<TaskModel, dynamic>(sql, new { id });
    }

    public Task<List<TaskModel>> GetUserTasks(string userId)
    {
        string sql = "select * from dbo.Tasks where AuthorId = @userId";

        return _db.LoadData<TaskModel, dynamic>(sql, new { userId });
    }

    public Task InsertTask(TaskModel task)
    {
        string sql = @"insert into dbo.Tasks (Task, Description, DateCreated, AuthorId, Category, Status, Notes, Archived)
                        values (@Task, @Description, @DateCreated, @AuthorId, @Category, @Status, @Notes, @Archived)";
        return _db.SaveData(sql, task);
    }

    public Task UpdateTask(TaskModel task)
    {
        string sql = @"update dbo.Tasks set Status = @Status, Notes = @Notes where Id = @id";
        return _db.SaveData(sql, task);
    }

    public Task ArchiveTask(TaskModel task)
    {
        string sql = @"update dbo.Tasks set Archived = @Archived where Id = @id";
        return _db.SaveData(sql, task);
    }
}
