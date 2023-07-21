using MassTransit.Core.Shared.ServiceBus;

namespace MassTransit.Infrastructure.Services.Events
{
    public class CreateTagEvent : IntegrationBaseEvent
    {
        public string TagName { get; set; }
    }
}
