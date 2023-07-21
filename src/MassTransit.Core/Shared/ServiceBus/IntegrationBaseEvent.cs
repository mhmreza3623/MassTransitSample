using System.Reflection.Metadata.Ecma335;

namespace MassTransit.Core.Shared.ServiceBus
{
    public class IntegrationBaseEvent
    {
        public IntegrationBaseEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }

        /// <summary>
        /// Constructor if you got an external method settings the properties.
        /// </summary>
        /// <param name="id">Event ID</param>
        /// <param name="creationDate">Event Creation Date</param>
        public IntegrationBaseEvent(Guid id, DateTime creationDate,string name)
        {
            Id = id;
            CreationDate = creationDate;
            Name = name;
        }

        /// <summary>
        /// Event ID
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Event Creation Date
        /// </summary>
        public DateTime CreationDate { get; private set; }

        public string Name { get; private set; }
    }
}