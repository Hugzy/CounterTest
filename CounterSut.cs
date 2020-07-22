namespace Counter.quickcheck
{
    public class CounterSut
    {
        private int I = 0;

        public void Inc()
        {
            I++;
        }

        public void Dec()
        {
            I--;
        }

        public int Get()
        {
            return I;
        }
        
    }
}