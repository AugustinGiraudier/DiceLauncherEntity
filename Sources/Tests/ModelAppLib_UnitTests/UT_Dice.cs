using System;
using System.Collections.Generic;
using ModelAppLib;
using Xunit;

namespace ModelAppLib_UnitTests
{
    public class UT_Dice
    {
        [Fact]
        public void CreateObjectNotNull()
        {
            var lst = new List<DiceSideType>();
            Dice d = new(lst);
            Assert.NotNull(d);
        }

        [Fact]
        public void GettingSidesNotNull()
        {
            var lst = new List<DiceSideType>();
            Dice d = new(lst);
            Assert.NotNull(d.SideTypes);
        }

        [Fact]
        public void AddingSidesWorking()
        {
            DiceSide ds = new("imgPath");
            DiceSideType dst = new DiceSideType(1, ds);
            var lst = new List<DiceSideType>();
            lst.Add(dst);
            Dice d = new(lst);
            Assert.Single(d.SideTypes);
        }

        [Fact]
        public void AddingSideThatAlreadyExistWorks()
        {
            DiceSideType dst = new DiceSideType(1, new DiceSide("imgPath"));
            var lst = new List<DiceSideType>();
            lst.Add(dst);
            Dice d = new(lst);
            d.addSide(dst);
            Assert.Single(d.SideTypes);
            Assert.Equal(2, d.SideTypes[0].NbSide);
        }

        [Fact]
        public void AddingMultipleSidesWorks()
        {
            var lst = new List<DiceSideType>();
            Dice d = new(lst);
            d.addSide(new DiceSideType(2, new DiceSide("img")));
            d.addSide(new DiceSideType(3, new DiceSide("img2")));
        }

        [Theory]
        [MemberData(nameof(GetDatasForDices))]
        public void EqualityComparerWorks(List<DiceSideType> dst1, List<DiceSideType> dst2, bool shouldItBeEqual)
        {
            Dice d1 = new(dst1);
            Dice d2 = new(dst2);
            Assert.Equal(shouldItBeEqual, d1.Equals(d2));
            Assert.Equal(shouldItBeEqual, d2.Equals(d1));
        }


        public static IEnumerable<object[]> GetDatasForDices()
        {
            yield return new object[]
            {
                new List<DiceSideType>{
                    new DiceSideType(1,new DiceSide("img1")),
                    new DiceSideType(1,new DiceSide("img1"))
                },
                new List<DiceSideType>{
                    new DiceSideType(2,new DiceSide("img1"))
                },
                true
            };

            yield return new object[]
            {
                new List<DiceSideType>{
                    new DiceSideType(1,new DiceSide("img1")),
                    new DiceSideType(1,new DiceSide("img2"))
                },
                new List<DiceSideType>{
                    new DiceSideType(2,new DiceSide("img1"))
                },
                false
            };
        }

    }
}
