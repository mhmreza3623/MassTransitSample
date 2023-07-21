using AutoMapper;
using MassTransit.Core.Entities;
using MassTransit.Core.Repositories;
using MassTransit.Core.Shared.ServiceBus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Infrastructure.Services.Consume
{
    public class EventConsumer : IConsumer<IntegrationBaseEvent>
    {
        private readonly IMapper mapper;
        private readonly IGeneralRepository<EventBusEntity> repository;
        private readonly ILogger<IntegrationBaseEvent> _logger;

        public EventConsumer(IMapper mapper, IGeneralRepository<EventBusEntity> repository, ILogger<IntegrationBaseEvent> logger)
        {
            this.mapper = mapper;
            this.repository = repository;
            this._logger = logger;
        }
        public async Task Consume(ConsumeContext<IntegrationBaseEvent> context)
        {
            var @event = mapper.Map<EventBusEntity>(context.Message);

            repository.Add(@event);

            await Task.CompletedTask;
        }
    }
}
