using Jaya.Domain.Tasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jaya.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public IEnumerable<TaskModel> GetAll()
        {

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new TaskModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToList();
        }
    }

}