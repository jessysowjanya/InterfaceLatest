using Xunit;
using System;
using InterfaceDemo;
namespace InterfaceDemoTest
{
    public class InterfaceTest
    {
        [Fact]
        public void SimpleInterest_ForValidInput()
        {
            IMath IObj = new InterfaceDemo.Math();
            double p = 200;
            double r = 2;
            double t = 2;
            SimpleInterest SI = new SimpleInterest(IObj);
            Assert.Equal(8, SI.Interest(p, t, r));
        }
        [Fact]
        public void CompoundInterest_ForValidInput()
        {
            IMath IObj = new InterfaceDemo.Math();
            double p = 200;
            double r = 5;
            double t = 2;
            CompoundInterest CI = new CompoundInterest(IObj);
            Assert.Equal(20.5, CI.Interest(p, t, r));
        }
    }
}