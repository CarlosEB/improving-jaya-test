using System.Collections.Generic;
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

        private readonly IIssueService _issueService;

        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<EventsController> _logger;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="taskService"></param>
        public EventsController(ILogger<EventsController> logger, IIssueService taskService)
        {
            _logger = logger;
            _issueService = taskService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("number/events")]
        public IEnumerable<IssueViewModel> GetAllEvents(long number)
        {
            return _issueService.GetAllEvents(number);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("number/lastevent")]
        public IssueViewModel GetLastEvent(long number)
        {
            return _issueService.GetLastEvent(number);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostEvent(object data)
        {

            _issueService.Save(data);

            return Ok();
        }

    }
}
