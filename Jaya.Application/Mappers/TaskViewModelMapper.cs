using Jaya.Application.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Jaya.Application.Mappers
{
    public class TaskViewModelMapper
    {
        public static IEnumerable<TaskViewModel> MapTasks(IEnumerable<TaskModel> models)
        {
            return models.Select(s => new TaskViewModel(s)).ToList();
        }
    }
}
