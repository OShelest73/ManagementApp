namespace ManagementAppLibrary.DataAccess
{
    public interface ITaskData
    {
        Task<List<TaskModel>> GetArchivedTasks();
        Task<List<TaskModel>> GetTasks();
        Task<TaskModel> GetTask(int id);
        Task InsertTask(TaskModel task);
        Task<List<TaskModel>> GetUserTasks(string userId);
        Task UpdateTask(TaskModel task);
        Task ArchiveTask(TaskModel task);
    }
}