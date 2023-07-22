using MassTransit.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Core.Dto
{
    public class TopicDto
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public List<string> Tags { get; set; }
    }
}
