using DataAccess.Context;
using DataAccess.Infrastructure;
using DataAccess.UnitOfWork;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Business.Service;
using System.Threading.Tasks;

namespace Business.Infrastructure
{
    public static class BusinessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            //services
            services.AddTransient(typeof(OrderService));
            services.AddTransient(typeof(CommentService));
            services.AddTransient(typeof(UserService));
            services.AddTransient(typeof(BookService));
            services.AddTransient(typeof(GenreService));
            services.AddTransient(typeof(OrderDetailService));
            services.AddTransient(typeof(TagService));



            DataAccessConfiguration.ConfigureServices(services, configuration);
        }
        public static async Task ConfigureIdentityInicializerAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await new IdentityInitializer(userManager, roleManager).SeedAsync();

        }
    }
}
