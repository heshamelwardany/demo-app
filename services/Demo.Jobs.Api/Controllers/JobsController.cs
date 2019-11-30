using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Jobs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobsController : ControllerBase
    {
        private static readonly string[] Titles = new[]
        {
            "Software Engineer", "Quality Engineer", "Business Analyst", "Product Owner", "Scrum Master"
        };

        private static readonly string[] Levels = new[]
        {
            "Junior", "MidLevel", "Senior", "Team Lead Level 1", "Team Lead Level 2", "Team Lead Level 3"
        };

        private readonly ILogger<JobsController> _logger;

        public JobsController(ILogger<JobsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Job> Get()
        {
            try
            {
                return Enumerable.Range(0, 4).Select(index => new Job
                {
                    Title = Titles[index],
                    Level = Levels[index]
                })
            .ToArray();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while retrieving jobs");
                return Enumerable.Empty<Job>();
            }
        }
    }
}
