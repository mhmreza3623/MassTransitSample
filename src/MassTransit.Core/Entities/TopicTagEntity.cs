namespace MassTransit.Core.Entities
{
    public class TopicTagEntity
    {
        public int TopicId { get; set; }
        public TopicEntity Topic { get; set; }

        public int TagId { get; set; }
        public TagEntity Tag { get; set; }

        public DateTime CreateDate { get; set; }

    }
}
