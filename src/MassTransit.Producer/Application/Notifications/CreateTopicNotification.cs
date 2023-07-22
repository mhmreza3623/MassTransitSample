using MassTransit.Core.Dto;
using MassTransit.Core.Entities;
using MediatR;

namespace MassTransit.Producer.Application.Notifications
{
    public record CreateTopicNotification(TopicDto topic) : INotification
    {
    }
}