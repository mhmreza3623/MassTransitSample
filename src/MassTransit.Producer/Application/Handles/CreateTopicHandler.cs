using MassTransit;
using MassTransit.Core.Dto;
using MassTransit.Core.Entities;
using MassTransit.Core.Repositories;
using MassTransit.Producer.Application.Commands;
using MassTransit.Producer.Application.Notifications;
using MediatR;

namespace MassTransit.Producer.Application.Handles;

public record CreateTopicHandler : IRequestHandler<CreateTopicCommand>
{
    private readonly IGeneralRepository<TopicEntity> repository;
    private readonly IMediator mediator;

    public CreateTopicHandler(IMediator mediator, IGeneralRepository<TopicEntity> repository)
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
            Tags = request.tags
        }));
    }
}
