using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using VicStelmak.CIAA.Infrastructure.DataAccess;
using VicStelmak.CIAA.Infrastructure.Identity;

namespace VicStelmak.CIAA.Infrastructure
{
    public static class DIContainersConfigurator
    {
        public static IServiceCollection ConfigureDependencyInjection(this
            IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CustomIdentityDbContextConnection") ?? 
                throw new InvalidOperationException("Connection string 'CustomIdentityDbContextConnection' not found.");
            services.AddDbContext<CustomIdentityDbContext>(options =>
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 33)), mySqlOptions =>
                {
                    mySqlOptions.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                    mySqlOptions.MigrationsAssembly(typeof(CustomIdentityDbContext).Assembly.FullName);
                }
            ));

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<CustomIdentityUser>>();

            return services;
        }
    }
}
