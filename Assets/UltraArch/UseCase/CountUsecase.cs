using MessagePipe;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnityCleanArchitectureExample
{
    public interface ICountDBGateway
    {
        void SetCount(CountType type, int new_value);
        int GetCount(CountType type);
    }
    public class CountUsecase : ICountUsecase
    {
        private readonly IPublisher<CountUpdatedMessage> _publisher;
        private readonly ICountDBGateway _gateway;

        public CountUsecase(IPublisher<CountUpdatedMessage> publisher, ICountDBGateway gateway)
        {
            _publisher = publisher;
            _gateway = gateway;
            var counts = new Dictionary<CountType, Count>
        {
            { CountType.A, new Count { Type = CountType.A, Num = _gateway.GetCount(CountType.A) } },
            { CountType.B, new Count { Type = CountType.B, Num = _gateway.GetCount(CountType.B) } }
        };
            _publisher.Publish(new CountUpdatedMessage(counts));
        }

        public void IncrementCount(CountType type)
        {
            var current = _gateway.GetCount(type);
            var newCount = current + 1;
            _gateway.SetCount(type, newCount);
            var counts = new Dictionary<CountType, Count>
        {
            { CountType.A, new Count { Type = CountType.A, Num = _gateway.GetCount(CountType.A) } },
            { CountType.B, new Count { Type = CountType.B, Num = _gateway.GetCount(CountType.B) } }
        };
  
            _publisher.Publish(new CountUpdatedMessage(counts));
        }
        public Dictionary<CountType, Count> GetCounts()
        {
            var counts = new Dictionary<CountType, Count>
        {
            { CountType.A, new Count { Type = CountType.A, Num = _gateway.GetCount(CountType.A) } },
            { CountType.B, new Count { Type = CountType.B, Num = _gateway.GetCount(CountType.B) } }
        };
            return counts;
        }

        public int GetCount(CountType type)
        {
            return _gateway.GetCount(type);
        }

    }

}

