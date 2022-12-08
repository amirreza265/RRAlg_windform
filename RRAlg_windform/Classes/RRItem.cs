namespace RRAlg_windform.Classes
{
    public class RRItem<T>
    {
        private int initialWeight;

        public RRItem(T data, int weight = 1)
        {
            Data = data;
            Weight = weight;

            InitialWeight = weight;
        }

        public T Data { get; set; }
        public int Weight { get; private set; }

        public int InitialWeight 
        { 
            get => initialWeight;

            private set { 
                if (value < 1)
                {
                    //throw Exception
                    return;
                }

                initialWeight = value;
            }
        }

        public ulong TotalWaitingTime { get; set; }

        public ulong LastUpadateTime { get; set; }

        public int DecreaseWeight(int weight = 1)
        {
            Weight -= weight;
            return Weight;
        }

        public double CompletePercentage() => (double)Weight / InitialWeight;

    }
}
