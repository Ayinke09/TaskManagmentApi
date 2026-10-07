using Microsoft.EntityFrameworkCore;
using TaskManagmentApi.Context;
using TaskManagmentApi.Model;
using TaskManagmentApi.Repository.Interface;

namespace TaskManagmentApi.Repository.Implementation
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly ApplicationDbContext _db;
        public TaskItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public TaskItem Item { get; private set; }

        public async Task<TaskItem> CreateTaskItemAsync(TaskItem Item)
        {
            var task = await _db.TaskItems.AddAsync(Item);
            await _db.SaveChangesAsync();
            return task.Entity;

        }

        public async Task DeleteTaskItemAsync(int id)
        {
            _db.TaskItems.Remove(await GetTaskItemByIdAsync(id)); 
        }

        public async Task<IEnumerable<TaskItem>> GetAllTaskItemAsync()
        {
            return await _db.TaskItems.ToListAsync();
        }

        public Task<TaskItem> GetTaskItemByIdAsync(int id)
        {
            return _db.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TaskItem> UpdateTaskItemAsync(TaskItem taskItem)
        {
            var task = _db.TaskItems.Update(Item);
            await _db.SaveChangesAsync();
            return task.Entity;
        }
    }
}
