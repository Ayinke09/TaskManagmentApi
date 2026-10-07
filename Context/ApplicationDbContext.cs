using Microsoft.EntityFrameworkCore;
using TaskManagmentApi.Model;

namespace TaskManagmentApi.Context
{
    public class ApplicationDbContext : DbContext

    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<TaskItem> TaskItems { get; set; } = null!;
    }
}
