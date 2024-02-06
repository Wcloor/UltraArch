using System.Collections.Generic;
namespace UnityCleanArchitectureExample
{
    public class CountUpdatedMessage
    {
        public Dictionary<CountType, Count> Counts { get; }
        public CountUpdatedMessage(Dictionary<CountType, Count> counts)
        {
            Counts = counts;
        }
    }
}

