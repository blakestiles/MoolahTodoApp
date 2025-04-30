using Microsoft.EntityFrameworkCore;
using MoolahTodoAPI.Models;

namespace MoolahTodoAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }


}
