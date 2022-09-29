using System;
using System.Collections.Generic;
using ModelAppLib;
using StubLib;
using Xunit;

namespace ModelAppLib_UnitTests
{
    public class UT_Stub
    {
        [Fact]
        public void CreateObjectNotNull()
        {
            var stub = new Stub();
            Assert.NotNull(stub);
        }

        [Fact]
        public void DiceCollectionNotEmpty()
        {
            var stub = new Stub();
            Assert.NotEmpty(stub.GetAllDices().Result);
        }

        [Fact]
        public void SideCollectionNotEmpty()
        {
            var stub = new Stub();
            Assert.NotEmpty(stub.GetAllSides().Result);
        }


    }
}
