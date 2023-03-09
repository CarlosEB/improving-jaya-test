using System;

namespace Jaya.Application.ViewModels
{
    public class TaskViewModel
    {
        public TaskViewModel()
        { }

        public TaskViewModel(TaskModel model)
        {
            Date = model.Date;
            TemperatureC = model.TemperatureC;
            Summary = model.Summary;
        }

        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }
}
