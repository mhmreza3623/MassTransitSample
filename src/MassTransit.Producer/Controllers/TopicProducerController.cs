using MassTransit.Producer.Application.Commands;
using MassTransit.Producer.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicProducerController : ControllerBase
    {

        private readonly ILogger<TopicProducerController> _logger;
        private readonly IMediator mediator;

        public TopicProducerController(ILogger<TopicProducerController> logger, IMediator mediator)
        {
            _logger = logger;
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddTopic([FromBody] TopicRequest request, CancellationToken ct)
        {
            await mediator.Send(new CreateTopicCommand(request.Title, request.Content, request.Tags.Split(",".ToCharArray()).ToList()), ct);

            return Ok();
        }
    }
}
