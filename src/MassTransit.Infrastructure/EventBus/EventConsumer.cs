using AutoMapper;
using MassTransit.Core.Entities;
using MassTransit.Core.Events.BaseEvents;
using MassTransit.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace MassTransit.Infrastructure.EventBus
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
            _logger = logger;
        }
        public async Task Consume(ConsumeContext<IntegrationBaseEvent> context)
        {
            //var @event = mapper.Map<EventBusEntity>(context.Message);

            repository.Add(new EventBusEntity()
            {

                Id = context.Message.Id,
                Content = context.Message.Content,
                CreateDate = context.Message.CreateDate,
            });

            await Task.CompletedTask;
        }
    }
}
