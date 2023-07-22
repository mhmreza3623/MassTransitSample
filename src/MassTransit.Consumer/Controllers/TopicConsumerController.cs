using MassTransit.Core.Entities;
using MassTransit.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.Consumer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicConsumerController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<TopicConsumerController> _logger;
        private readonly IGeneralRepository<TopicEntity> repository;

        public TopicConsumerController(ILogger<TopicConsumerController> logger, IGeneralRepository<TopicEntity> repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpGet(Name = "GetLastTopic")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}