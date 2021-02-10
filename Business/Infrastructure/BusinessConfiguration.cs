﻿using DataAccess.Context;
using DataAccess.Infrastructure;
using DataAccess.UnitOfWork;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Infrastructure
{
    public static class BusinessConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            //services
            services.AddTransient(typeof(AddressService));
            services.AddTransient(typeof(BrandService));
            services.AddTransient(typeof(CategoryService));
            services.AddTransient(typeof(CharacteristicService));
            services.AddTransient(typeof(IDeliveryService), typeof(DeliveryService));
            services.AddTransient(typeof(ProductCharacteristicService));
            services.AddTransient(typeof(ImageService));
            services.AddTransient(typeof(OrderService));
            services.AddTransient(typeof(OrderDetailsService));
            services.AddTransient(typeof(PackageService));
            services.AddTransient(typeof(ProductService));
            services.AddTransient(typeof(ImportExportService));
            services.AddTransient(typeof(CommentService));
            services.AddTransient(typeof(UserService));
            services.AddTransient(typeof(LikeService));
            services.AddTransient(typeof(NewsSenserService));
            services.AddTransient(typeof(NewsSaveService));
            services.AddTransient<ImageFileService>(service => new ImageFileService($"{ Directory.GetCurrentDirectory()}\\wwwroot\\Content\\Images\\"));



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
