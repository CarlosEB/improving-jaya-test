using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jaya.Application.Services;
using Jaya.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Jaya.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {

        private readonly ITaskService _taskService;

        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<EventsController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="taskService"></param>
        public EventsController(ILogger<EventsController> logger, ITaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<TaskViewModel> Get()
        {
            return _taskService.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostEvent(object data)
        {

            return Ok();
        }

    }
}
