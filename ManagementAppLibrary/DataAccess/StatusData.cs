using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementAppLibrary.DataAccess;

public class StatusData : IStatusData
{
    private readonly ISqlDataAccess _db;

    public StatusData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<List<StatusModel>> GetAllStatuses()
    {
        string sql = "select * from dbo.Statuses";

        return _db.LoadData<StatusModel, dynamic>(sql, new { });
    }

    public Task<StatusModel> FindStatus(string id)
    {
        string sql = "select * from dbo.Statuses where StatusName = @id";

        return _db.FindElement<StatusModel, dynamic>(sql, new { id });
    }

    public Task InsertStatus(StatusModel status)
    {
        string sql = @"insert into dbo.Statuses (StatusName) values (@StatusName)";
        return _db.SaveData(sql, status);
    }
}
