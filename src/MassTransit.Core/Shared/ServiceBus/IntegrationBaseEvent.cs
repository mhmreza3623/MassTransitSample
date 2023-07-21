using System.Reflection.Metadata.Ecma335;

namespace MassTransit.Core.Shared.ServiceBus
{
    public class IntegrationBaseEvent
    {
        /// <summary>
        /// Constructor if you got an external method settings the properties.
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <param name="creationDate">Event Creation Date</param>
        public IntegrationBaseEvent(Guid id, DateTime creationDate,string content)
        {
            Id = id;
            CreationDate = creationDate;
            Content = content;
        }

        /// <summary>
        /// Event ID
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Event Creation Date
        /// </summary>
        public DateTime CreationDate { get; private set; }

        public string Content { get; private set; }
    }
}