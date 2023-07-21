using MassTransit.Application.Commands;
using MassTransit.Application.Notifications;
using MassTransit.Core.Entities;
using MassTransit.Core.Repositories;
using MediatR;

namespace MassTransit.Application.Handlera;

public record CreateTopicHandler : IRequestHandler<CreateTopicCommand>
{
    private readonly IGeneralRepository<TopicEntity> repository;
    private readonly IMediator mediator;

    public CreateTopicHandler(IGeneralRepository<TopicEntity> repository,IMediator mediator)
    {
        this.repository = repository;
        this.mediator = mediator;
    }


    public async Task Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var topic = repository.Add(new TopicEntity
        {
            Content = "Hello",
            Title = "Topic1",
            Tags = new List<TopicTagEntity> {
                new TopicTagEntity
                {
                    Tag=new TagEntity{Title="Food"},
                    CreateDate=DateTime.Now,
                }
            }
        });

        await mediator.Publish(new CreateTopicNotification(topic));
    }
}
