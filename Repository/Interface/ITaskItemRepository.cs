using TaskManagmentApi.Model;

namespace TaskManagmentApi.Repository.Interface
{
    public interface ITaskItemRepository
    {
        Task<IEnumerable<TaskItem>> GetAllTaskItemAsync();
        Task<TaskItem> GetTaskItemByIdAsync(int id);
        Task<TaskItem> CreateTaskItemAsync(TaskItem taskItem);
        Task<TaskItem> UpdateTaskItemAsync(TaskItem taskItem);
        Task DeleteTaskItemAsync(int id);
    }
}
