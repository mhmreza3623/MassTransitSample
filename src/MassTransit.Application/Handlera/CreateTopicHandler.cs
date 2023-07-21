using MassTransit.Core.Entities;
using MassTransit.Core.Repositories;
using MediatR;

namespace MassTransit.Application.Commands;

public record CreateTopicHandler : IRequestHandler<CreateTopicCommand>
{
    private readonly IGeneralRepository<TopicEntity> repository;

    public CreateTopicHandler(IGeneralRepository<TopicEntity> repository)
    {
        this.repository = repository;
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
    }
}
