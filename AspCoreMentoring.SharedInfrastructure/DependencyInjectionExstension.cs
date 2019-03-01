﻿using AspCoreMentoring.DAL.Common.Interfaces;
using AspCoreMentoring.DAL.DbContext;
using AspCoreMentoring.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AspCoreMentoring.Service.Common.Interfaces;
using AspCoreMentoring.Service.Services;

namespace AspCoreMentoring.SharedInfrastructure
{
    public static class DependencyInjectionExstension
    {
        public static void RegisterDALDependency(this IServiceCollection serviceCollection,IConfiguration configuration)
        {
            serviceCollection.AddDbContext<NorthWindContext>(option => {
                option.UseSqlServer(configuration.GetConnectionString("NorthwindDb"));
            });
            serviceCollection.AddScoped<IProductRepository, ProductRepository>();
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddScoped<ISupplierRepository, SupplierRepository>();
        }

        public static void RegisterBLDependency(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IProductService, ProductService>();
        }
    }
}
