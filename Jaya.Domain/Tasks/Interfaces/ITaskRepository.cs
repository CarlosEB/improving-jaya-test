using System;
using System.Collections.Generic;
using System.Text;

namespace Jaya.Domain.Tasks.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<TaskModel> GetAll();
    }
}
