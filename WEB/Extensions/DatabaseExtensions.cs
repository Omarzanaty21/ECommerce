using Microsoft.EntityFrameworkCore;
using WEB.Data;

namespace WEB.Extensions
{
    public static class DatabaseExtensions
    {
        public static void AddDatabaseConnection(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DatabaseContext>(c => c.UseSqlite(config.GetConnectionString("default")));
        }

        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            
            context.Database.Migrate();
            DatabaseContextSeed.SeedData(context);
        }
    }
}