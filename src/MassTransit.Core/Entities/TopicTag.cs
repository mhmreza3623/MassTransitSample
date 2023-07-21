
namespace MassTransit.Core.Entities
{
    public class TagEntity : BaseEntity
    {
        public string Title { get; set; }

        public ICollection<TopicTagEntity> Topics { get; set; }

    }
}
