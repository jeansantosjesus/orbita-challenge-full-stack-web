using EdTechAPI.Model;
using EdTechAPI.Structure;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace EdTechAPI.Services
{
    public static class DatabaseManagementService
    {
        public static void MigrationInitialization(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider
                                .GetService<ConnectionContext>();
                
                serviceDb.Database.Migrate();
            }
        }
    }
}
