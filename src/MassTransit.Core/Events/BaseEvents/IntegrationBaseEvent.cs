using System.Reflection.Metadata.Ecma335;

namespace MassTransit.Core.Events.BaseEvents
{
    public class IntegrationBaseEvent : BaseEvent
    {
        public string Content { get; set; }
    }
}