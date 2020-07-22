using FsCheck;
using FsCheck.Experimental;

namespace Counter.quickcheck
{
    public class CounterSpecVNextInt : Machine<CounterSut, int>
    {
        public override Gen<Operation<CounterSut, int>> Next(int obj0)
        {
            return Gen.Elements(new Operation<CounterSut, int>[] {new Inc()});
        }

        public override Arbitrary<Setup<CounterSut, int>> Setup => Arb.From(Gen.Constant(SetupTest()));

        private Setup<CounterSut, int> SetupTest()
        {
            return new CounterSetup();
        }
        

        private class CounterSetup : Setup<CounterSut, int>
        {
            public override CounterSut Actual()
            {
                return new CounterSut();
            }

            public override int Model()
            {
                return 0;
            }
        }

        private class Inc : BaseOperation
        {
            public override Property Check(CounterSut obj0, int obj1)
            {
                obj0.Inc();
                return (obj0.Get() == obj1).ToProperty();
            }

            public override int Run(int obj0)
            {
                return ++obj0;
            }
        }

        private class Dec : BaseOperation
        {

            public override Property Check(CounterSut obj0, int obj1)
            {
                obj0.Dec();
                return (obj0.Get() == obj1).ToProperty();
            }

            public override int Run(int i)
            {
                return --i;
            }
        }

        private abstract class BaseOperation : Operation<CounterSut, int>
        {
            public override string ToString()
            {
                return GetType().Name;
            }
        }

    }
}