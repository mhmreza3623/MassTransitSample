using MassTransit.Api.Models;
using MassTransit.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddTopic([FromBody] TopicRequest request, CancellationToken ct)
        {
            await mediator.Send(new CreateTopicCommand(request.TopicName), ct);
            return Ok();
        }
    }
}