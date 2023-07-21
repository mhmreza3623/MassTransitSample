using MassTransit.Core.Shared.ServiceBus;

namespace MassTransit.Core.Events.Tag
{
    public class CreateTagEvent : IntegrationBaseEvent
    {
        public CreateTagEvent(Guid id, DateTime creationDate, string content) : base(id, creationDate, content)
        {
        }
    }
}
