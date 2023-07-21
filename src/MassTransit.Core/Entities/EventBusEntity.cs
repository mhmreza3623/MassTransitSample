using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Core.Entities
{
    public class EventBusEntity
    {
        public EventBusEntity()
        {
            Id = Guid.NewGuid();
        }


        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
