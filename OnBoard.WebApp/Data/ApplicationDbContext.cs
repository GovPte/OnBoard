using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using OnBoard.WebApp.Models;

namespace OnBoard.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUserModels>
    {
        //To update the database (make sure blank "OnBoard" database created first)
        //  Open View > Package Manager Console

        //dotnet ef migrations add Migration00* --project OnBoard.WebApp --context ApplicationDbContext (updates Project)
        //dotnet ef database update --project OnBoard.WebApp --context ApplicationDbContext --startup-project OnBoard.WebApp (updates Database)

        public IConfiguration Configuration { get; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options) 
        {
            Configuration = configuration;
        }

        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //using appsettings.json instead...
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        //TO-DO: Insert Roles - 1/Administrator, 2/Manager, 3/User, 4/Resident

        //TO-DO: Insert first user account and an 1/Administrator
    }
}