using MassTransit.Core.Dto;
using MassTransit.Core.Entities;
using MediatR;

namespace MassTransit.Application.Notifications
{
    public record CreateTopicNotification(TopicDto topic) : INotification
    {
    }
}