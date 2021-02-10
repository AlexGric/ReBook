using DataAccess.Context;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Infrastructure
{
    public static class DataAccessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient(typeof(ICommentRepository), typeof(CommentRepository));
            services.AddTransient(typeof(IUserRepository), typeof(UserRepository));
            services.AddDbContext<LibraryContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("myconn")));

        }
    }
}
