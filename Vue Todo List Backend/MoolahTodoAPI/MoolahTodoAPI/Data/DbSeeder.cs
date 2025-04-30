using MoolahTodoAPI.Models;

namespace MoolahTodoAPI.Data
{
    public static class DbSeeder
    {
        public static void SeedDatabase(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        }
    }
}
