using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Messaging.Publisher.Interfaces
{
    public interface IEventPublisher
    {
        Task Publish<T>(T eventMessage) where T : class;
    }
}
