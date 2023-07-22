using AutoMapper;
using MassTransit.Core.Events.Topics;
using MassTransit.Producer.Application.Notifications;
using MediatR;
using System.Text.Json;

namespace MassTransit.Producer.Application.NotificationHandlers
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
            await publishEndpoint.Publish(new CreateTopicEvent()
            {
                Title = notification.topic.Title,
                Content = JsonSerializer.Serialize(notification.topic),
                Tags = notification.topic.Tags,
            });
        }
    }
}
