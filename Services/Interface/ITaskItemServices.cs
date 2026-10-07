using TaskManagmentApi.Controllers;
using TaskManagmentApi.DTO;

namespace TaskManagmentApi.Services.Interface
{
    public interface ITaskItemServices
    {
        Task<IEnumerable<TaskItemResponseDto>> GetAllTaskItemAsync();
        Task<TaskItemResponseDto> GetTaskITemByIdAsync(int id);
        Task<TaskItemResponseDto> CreateTaskItemAsync(CreateTaskItemDto dto);
        Task<TaskItemResponseDto> UpdateTaskItemAsync( int id ,UpdateTaskItemDto dto);

        Task DeleteTaskItemAsync(int id);
    }
}
