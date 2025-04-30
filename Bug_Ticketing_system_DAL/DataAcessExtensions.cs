using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Ticketing_System.DAL.Repositories.AttachmentRepo;
using Bug_Ticketing_System.DAL.Repositories.Bug_UserRepo;
using Bug_Ticketing_System.DAL.Repositories.BugRepo;
using Bug_Ticketing_system_DAL.Repositories.ProjectRepo;
using Bug_Ticketing_system_DAL.UnitOfWork;
using Bug_Ticketing_System_DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bug_Ticketing_System_DAL
{
    public static class DataAcessExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<BugDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Bug_Ticketing_system_DAL"))); // Specify the migrations assembly



            services.AddScoped<IBugRepo, BugRepo>();
            services.AddScoped<IProjectRepo, ProjectRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBug_UserRepo, Bug_UserRepo>();
            services.AddScoped<IAttachmentRepo, AttachmentRepo>();

        }
    }
}
