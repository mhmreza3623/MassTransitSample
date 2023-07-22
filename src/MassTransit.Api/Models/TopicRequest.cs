namespace MassTransit.Producer.Models
{
    public class TopicRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags{ get; set; }
    }
}
