using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MassTransit.Application.Commands
{
    public record CreateTopicCommand(string title,string content,List<string> tags) : IRequest;
}
