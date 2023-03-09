using Jaya.Application.ViewModels;
using System.Collections.Generic;

namespace Jaya.Application.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskViewModel> GetAll();
    }
}
