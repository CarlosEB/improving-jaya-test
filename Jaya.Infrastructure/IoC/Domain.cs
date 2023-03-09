
using Jaya.Application.Services;
using Jaya.Domain.Tasks.Interfaces;
using Jaya.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Jaya.Infrastructure.IoC

{
    public static class Domain
    {

        public static void Initiate(IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITaskRepository, TaskRepository>();
        }

    }
}