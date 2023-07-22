using MassTransit.Core.Entities;
using MassTransit.Core.Events.BaseEvents;
using MassTransit.Core.Events.Topics;
using MassTransit.Core.Repositories;

namespace MassTransit.Consumer.EventHandlers
{
    public class TopicCreatedEventHandler : IConsumer<CreateTopicEvent>
    {
        private readonly IGeneralRepository<TopicEntity> repository;

        public TopicCreatedEventHandler(IGeneralRepository<TopicEntity> repository)
        {
            this.repository = repository;
        }


        public async Task Consume(ConsumeContext<CreateTopicEvent> context)
        {
            var topic = repository.Add(new TopicEntity
            {
                Content = context.Message.Content,
                Title = context.Message.Title,
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
}
