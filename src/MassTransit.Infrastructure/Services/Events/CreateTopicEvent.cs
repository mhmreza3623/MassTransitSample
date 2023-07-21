﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit.Core.Shared.ServiceBus;

namespace MassTransit.Infrastructure.Services.Events
{
    public class CreateTopicEvent: IntegrationBaseEvent
    {
        public string TopicName { get; set; }
    }
}
