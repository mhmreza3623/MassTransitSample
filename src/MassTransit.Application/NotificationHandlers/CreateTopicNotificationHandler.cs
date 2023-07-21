using AutoMapper;
using MassTransit.Application.Notifications;
using MassTransit.Core.Events.Topics;
using MediatR;
using System.Text.Json;

namespace MassTransit.Application.NotificationHandlers
{
    internal class CreateTopicNotificationHandler : INotificationHandler<CreateTopicNotification>
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly IMapper mapper;

        public CreateTopicNotificationHandler(IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            this.publishEndpoint = publishEndpoint;
            this.mapper = mapper;
        }
        public async Task Handle(CreateTopicNotification notification, CancellationToken cancellationToken)
        {
            //CreateTopicEvent topicEvent = mapper.Map<CreateTopicEvent>(notification.topicEntity);

            await publishEndpoint.Publish(new CreateTopicEvent()
            {
                Title = notification.topicEntity.Title,
                Content = JsonSerializer.Serialize(new
                {
                    Id = notification.topicEntity.Id,
                    Title = notification.topicEntity.Title
                })
            });
        }
    }
}
