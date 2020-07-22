using System.Collections.Generic;
using System.Linq;
using FsCheck;
using FsCheck.Experimental;
using NUnit.Framework;

namespace Counter.quickcheck
{
    public class CounterSpecVNext : Machine<CounterSut, List<int>>
    {
        public override Gen<Operation<CounterSut, List<int>>> Next(List<int> obj0)
        {
            return Gen.Elements(new Operation<CounterSut, List<int>>[] {new Inc()});
        }

        public override Arbitrary<Setup<CounterSut, List<int>>> Setup => Arb.From(Gen.Constant(SetupTest()));

        private Setup<CounterSut, List<int>> SetupTest()
        {
            return new CounterSetup();
        }
        

        private class CounterSetup : Setup<CounterSut, List<int>>
        {
            public override CounterSut Actual()
            {
                return new CounterSut();
            }

            public override List<int> Model()
            {
                return new List<int>() {0};
            }
        }

        private class Inc : BaseOperation
        {
            public override Property Check(CounterSut obj0, List<int> obj1)
            {
                obj0.Inc();
                return (obj0.Get() == obj1.Last()).ToProperty();
            }

            public override List<int> Run(List<int> obj0)
            {
                obj0.Add((obj0.Last()+1));
                return obj0;
            }
        }

        private class Dec : BaseOperation
        {

            public override Property Check(CounterSut obj0, List<int> obj1)
            {
                obj0.Dec();
                return (obj0.Get() == obj1.Last()).ToProperty();
            }

            public override List<int> Run(List<int> i)
            {
                i.Add((i.Last()-1));
                return i;
            }
        }

        private abstract class BaseOperation : Operation<CounterSut, List<int>>
        {
            public override string ToString()
            {
                return GetType().Name;
            }
        }
        
    }
}