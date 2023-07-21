using AutoMapper;
using MassTransit.Core.Dto;
using MassTransit.Core.Entities;
using MassTransit.Core.Shared.ServiceBus;

namespace MassTransit.Core.Mapper
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<TopicDto, TopicEntity>();
            CreateMap<IntegrationBaseEvent, EventBusEntity>();
        }
    }
}
