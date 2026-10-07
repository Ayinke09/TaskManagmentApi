using TaskManagmentApi.DTO;
using TaskManagmentApi.Model;
using TaskManagmentApi.Repository.Interface;
using TaskManagmentApi.Services.Interface;

namespace TaskManagmentApi.Services.Implementation
{
    public class TaskItemServices : ITaskItemServices
    {
        private readonly ITaskItemRepository _repo;
         public TaskItemServices(ITaskItemRepository repo)

        {
            _repo = repo;
        }

        public async Task<TaskItemResponseDto> CreateTaskItemAsync(CreateTaskItemDto dto)
        {
            var task = new TaskItem
            {
                Description = dto.Description,
                Title = dto.Title,
                IsCompleted = dto.IsCompleted,
               
            };
            var created = await _repo.CreateTaskItemAsync(task);
            if (created == null) return null;
            return new TaskItemResponseDto
            {
                Description = created.Description,
                Title = created.Title,
                IsCompleted = created.IsCompleted,
             

            };
        }

        public async Task DeleteTaskItemAsync(int id)
        {
            await _repo.DeleteTaskItemAsync(id);
        }

        public async Task<IEnumerable<TaskItemResponseDto>> GetAllTaskItemAsync(int id)
        {
            var tasks = await _repo.GetAllTaskItemAsync();
            return tasks.Select(t => new TaskItemResponseDto
            {
                Description = t.Description,
                Title = t.Title,
                IsCompleted = t.IsCompleted,
               
            });
        }

        public Task<IEnumerable<TaskItemResponseDto>> GetAllTaskItemAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<TaskItemResponseDto> GetTaskITemByIdAsync(int id)
        {
            var created = await _repo.GetTaskItemByIdAsync(id);
            return new TaskItemResponseDto
            {
                Description = created.Description,
                Title = created.Title,
                IsCompleted = created.IsCompleted,
            };
        }

        public async Task<TaskItemResponseDto> UpdateTaskItemAsync(int id,UpdateTaskItemDto dto)
        {
            var task = await _repo.GetTaskItemByIdAsync(id);
            task.Description = !string.IsNullOrEmpty(dto.Description) && dto.Description != task.Description ? dto.Description : task.Description;
            task.Title = !string.IsNullOrEmpty(dto.Title)&& dto.Title != task.Title ? dto.Title : task.Title;
            task.IsCompleted = dto.IsCompleted;

            await _repo.UpdateTaskItemAsync(task);
            return new TaskItemResponseDto
            {
                Description = task.Description,
                Title = task.Title,
                IsCompleted=task.IsCompleted,
            };
        }
    }
}

