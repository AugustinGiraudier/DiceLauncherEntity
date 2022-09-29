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

        [Theory]
        [InlineData(3,5)]
        [InlineData(1,0)]
        [InlineData(9,3)]
        public void CheckGettingSomeSides(int nbSides, int pageNum)
        {
            var stub = new Stub();
            var result = stub.GetSomeSides(nbSides, pageNum).Result;

            Assert.Equal(nbSides, result.Count);
            Assert.Equal("img" + (int)(nbSides * pageNum), result[0].Image);
            Assert.Equal("img" + (int)((nbSides * pageNum)+nbSides-1), result[result.Count-1].Image);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(20)]
        [InlineData(100)]
        public void CheckGettingSomeDices(int nbSides)
        {
            var stub = new Stub();
            var result = stub.GetSomeDices(nbSides, 1).Result;

            Assert.Equal(nbSides, result.Count);
        }

    }
}
