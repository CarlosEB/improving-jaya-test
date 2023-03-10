
using Jaya.Application.Services;
using Jaya.Domain.Issues.Interfaces;
using Jaya.Infrastructure.DataAccess;
using Jaya.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jaya.Infrastructure.IoC

{
    public static class Domain
    {

        public static void Initiate(IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DomainContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IIssueService, IssueService>();
            services.AddScoped<IIssueRepository, IssueRepository>();
        }

    }
}