using MassTransit.Core.Entities;
using MediatR;

namespace MassTransit.Application.Notifications
{
    public record CreateTopicNotification(TopicEntity topicEntity) : INotification
    {
    }
}