using DepBoard.Application.Interfaces;
using DepBoard.Application.Services;
using DepBoard.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DepBoard.CrossCutting
{
    public static class InjecaoDependencia
    {
        public static IServiceCollection AddServicosApplication(
            this IServiceCollection services)
        {
            services.AddScoped<AlunosServices>();
            services.AddScoped<NotasServices>();
            services.AddScoped<CursosServices>();
            return services;
        }

        public static IServiceCollection AddServicosInfra(
            this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DepBoardDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IDbContext>(provider => provider.GetRequiredService<DepBoardDbContext>());
            return services;
        }
    }
}
