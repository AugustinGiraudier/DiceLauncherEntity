using System;
using ModelAppLib;
using Xunit;

namespace ModelAppLib_UnitTests
{
    public class UT_Dice
    {
        [Fact]
        public void Creat()
        {
            Dice d = new();
            Assert.NotNull(d);
        }
    }
}
