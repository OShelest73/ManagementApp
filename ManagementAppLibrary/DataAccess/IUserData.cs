namespace ManagementAppLibrary.DataAccess
{
    public interface IUserData
    {
        Task AppointUser(string userId, int taskId);
        Task ChangePassword(UserModel user);
        Task CreateUser(UserModel user);
        Task<UserModel> FindUserAccount(string id);
        Task<UserModel> FindUserInformation(string id);
        Task<List<UserModel>> GetAppointedUsers(int taskId);
        Task<List<UserModel>> GetUsersInformation();
        Task<List<UserModel>> GetUsersToAppoint(string category);
        Task RemoveFromUser(string userId);
        Task RemoveTaskFromUsers(int taskId);
    }
}