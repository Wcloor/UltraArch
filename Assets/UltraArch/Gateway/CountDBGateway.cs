namespace UnityCleanArchitectureExample
{
    public class CountDBGateway : ICountDBGateway
    {
        private readonly Count CountA;
        private readonly Count CountB;
        public CountDBGateway()
        {
            CountA = new Count { Type = CountType.A };
            CountB = new Count { Type = CountType.B };
        }

        public int GetCount(CountType type)
        {
            if (type == CountType.A)
            {
                return CountA.Num;
            }
            else if (type == CountType.B)
            {
                return CountB.Num;
            }
            else
            {
                return default;
            }
        }

        public void SetCount(CountType type, int new_value)
        {
            if (type == CountType.A)
            {
                CountA.Num = new_value;
            }
            else if (type == CountType.B)
            {
                CountB.Num = new_value;
            }
        }
    }
}