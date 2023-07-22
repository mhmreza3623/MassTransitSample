namespace MassTransit.Core.Events.BaseEvents
{
    public class BaseEvent
    {
        public BaseEvent()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }

        /// <summary>
        /// Event ID
        /// </summary>
        public Guid Id { get; private set; }
        /// <summary>
        /// Event Creation Date
        /// </summary>
        public DateTime CreateDate { get; private set; }
    }
}