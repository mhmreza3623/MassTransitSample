using AutoMapper;
using MassTransit.Core.Dto;
using MassTransit.Core.Entities;
using MassTransit.Core.Events.Tag;
using MassTransit.Core.Events.Topics;

namespace MassTransit.Core.Mapper
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<TopicDto, TopicEntity>();
            CreateMap<TopicTagEntity, CreateTopicEvent>();
            CreateMap<TagEntity, CreateTagEvent>();
        }
    }
}
