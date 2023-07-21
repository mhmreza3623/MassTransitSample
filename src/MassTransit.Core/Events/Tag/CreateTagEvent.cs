using MassTransit.Core.Events.BaseEvents;
using System.Reflection.Metadata.Ecma335;

namespace MassTransit.Core.Events.Tag
{
    public class CreateTagEvent : IntegrationBaseEvent
    {
        public string Title { get; set; }
    }
}
