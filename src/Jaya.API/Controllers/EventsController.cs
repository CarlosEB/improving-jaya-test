using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Jaya.Application.Services;
using Jaya.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

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
        /// Get all events of an issue based on number
        /// </summary>
        /// <returns></returns>
        [HttpGet("{number}/events")]
        public async Task<ActionResult<IEnumerable<IssueViewModel>>> GetAllEvents(long number)
        {
            var result = await _issueService.GetAllEventsAsync(number);

            if (result.Count == 0)
            {
                _logger.LogInformation("Number {0} does not exist in the database", number);
                return NoContent();
            }

            return Ok(result);
        }

        /// <summary>
        /// Get the latest issue's event based on number
        /// </summary>
        /// <returns></returns>
        [HttpGet("{number}/lastevent")]
        public async Task<ActionResult<IssueViewModel>> GetLastEvent(long number)
        {
            var result = await _issueService.GetLastEventAsync(number);
            if (result.Number == 0)
            {
                _logger.LogInformation("Number {0} does not exist in the database", number);
                return NoContent();
            }

            return Ok(result);
        }

        /// <summary>
        /// Save the Issue in the Database
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostEvent(object data)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = 
                JsonSerializer.Deserialize<PayloadViewModel>(JObject.Parse(data.ToString()).Root.ToString(), options);

            await _issueService.SaveAsync(result);

            return Ok();
        }

    }
}
