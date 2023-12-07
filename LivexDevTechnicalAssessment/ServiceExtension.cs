using Microsoft.EntityFrameworkCore;
using LivexDevTechnicalAssessment.Entities.Models;
using LivexDevTechnicalAssessment.Contracts;
using LivexDevTechnicalAssessment.Repository;

namespace LivexDevTechnicalAssessment.Web
{
    public static class ServiceExtension
    {

        public static void AddDatabaseService(this IServiceCollection services, IConfiguration configuration)
        {
            //Initialize DB creation if DB is null
            InitializeDatabase();

            services.AddDbContext<InventoryDbContext>(options =>
            options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        private static void InitializeDatabase()
        {
            using var context = new InventoryDbContext();
            // Creates the database if not exists => Code first

            context.Database.EnsureCreated();

            // Saves changes
            context.SaveChanges();
        }
    }
}