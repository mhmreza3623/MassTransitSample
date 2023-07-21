using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Core.Entities
{
    public class TopicEntity : BaseEntity
    {
        public TopicEntity() {
            
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public ICollection<TopicTagEntity> Tags { get; set; }
    }
}
