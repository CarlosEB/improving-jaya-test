

using Jaya.Application.Mappers;
using Jaya.Application.ViewModels;
using Jaya.Domain.Tasks.Interfaces;
using System.Collections.Generic;

namespace Jaya.Application.Services
{
    public class TaskService : ITaskService
    {

        private ITaskRepository _repo;

        public TaskService(ITaskRepository repo)
        {
            _repo = repo;

        }

        public IEnumerable<TaskViewModel> GetAll()
        {
            return TaskViewModelMapper.MapTasks(_repo.GetAll());
        }
    }
}
