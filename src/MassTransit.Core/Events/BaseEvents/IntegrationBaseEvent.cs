using System.Reflection.Metadata.Ecma335;

namespace MassTransit.Core.Events.BaseEvents
{
    public class IntegrationBaseEvent
    {
        public IntegrationBaseEvent()
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