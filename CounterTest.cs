using FsCheck;
using FsCheck.Experimental;
using NUnit.Framework;

namespace Counter.quickcheck
{
    [TestFixture]
    public class CounterTest
    {
        [Test]
        public void TestSuite()
        {
            var config = Configuration.QuickThrowOnFailure;
            config.MaxNbOfTest = 5;
            Counter().Check(config);
        }
        
        [Property("", 1)]
        public Property Counter()
        {
            // return new CounterSpecVNext().ToProperty();
            return new CounterSpecVNextInt().ToProperty();
        }
    }
}