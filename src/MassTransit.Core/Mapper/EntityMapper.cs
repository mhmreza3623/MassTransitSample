using AutoMapper;
using MassTransit.Core.Dto;
using MassTransit.Core.Entities;

namespace MassTransit.Core.Mapper
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<TopicEntity, TopicDto>();
        }
    }
}
