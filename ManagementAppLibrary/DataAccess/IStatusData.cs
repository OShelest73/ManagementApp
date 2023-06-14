namespace ManagementAppLibrary.DataAccess
{
    public interface IStatusData
    {
        Task<StatusModel> FindStatus(string id);
        Task<List<StatusModel>> GetAllStatuses();
        Task InsertStatus(StatusModel status);
    }
}