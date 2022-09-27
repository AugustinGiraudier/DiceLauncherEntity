using System;
using System.Collections.Generic;
using ModelAppLib;
using Xunit;

namespace ModelAppLib_UnitTests
{
    public class UT_DiceStorage
    {

        [Fact]
        public void CreateObjectNotNull()
        {
            var storage = new DiceStorage(
                new List<Dice>
                {
                    new Dice(new DiceSideType(1, new DiceSide("img1")))
                },
                new List<DiceSide>
                {
                    new DiceSide("img1")
                });

            Assert.NotNull(storage);
        }

        [Fact]
        public void CreateObjectWithNullCollections()
        {
            var storage = new DiceStorage(null,null);
            Assert.NotNull(storage);
            Assert.NotNull(storage.Dices);
            Assert.NotNull(storage.Sides);
        }

        [Fact]
        public void GetSides()
        {
            var storage = new DiceStorage(
                            new List<Dice>
                            {
                                new Dice(new DiceSideType(1, new DiceSide("img1")))
                            },
                            new List<DiceSide>
                            {
                                new DiceSide("img1")
                            });
            Assert.NotNull(storage.Sides);
            Assert.Single(storage.Sides);
        }

        [Fact]
        public void GetDices()
        {
            var storage = new DiceStorage(
                            new List<Dice>
                            {
                                new Dice(new DiceSideType(1, new DiceSide("img1")))
                            },
                            new List<DiceSide>
                            {
                                new DiceSide("img1")
                            });
            Assert.NotNull(storage.Dices);
            Assert.Single(storage.Dices);
        }


    }
}
