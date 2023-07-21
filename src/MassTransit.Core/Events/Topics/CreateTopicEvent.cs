using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit.Core.Events.BaseEvents;

namespace MassTransit.Core.Events.Topics
{
    public class CreateTopicEvent : IntegrationBaseEvent
    {
        public CreateTopicEvent(Guid id, DateTime creationDate, string content) : base(id, creationDate, content)
        {
        }
    }
}
