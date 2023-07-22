using MassTransit.Application.Commands;
using MassTransit.Application.Notifications;
using MassTransit.Core.Dto;
using MassTransit.Core.Entities;
using MassTransit.Core.Repositories;
using MediatR;

namespace MassTransit.Application.Handlera;

public record CreateTopicHandler : IRequestHandler<CreateTopicCommand>
{
    private readonly IGeneralRepository<TopicEntity> repository;
    private readonly IMediator mediator;

    public CreateTopicHandler(IMediator mediator)
    {
        this.repository = repository;
        this.mediator = mediator;
    }


    public async Task Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        await mediator.Publish(new CreateTopicNotification(new TopicDto
        {
            Content = request.content,
            Title = request.title,
            Tags = new List<string> { "food" }
        }));
    }
}
