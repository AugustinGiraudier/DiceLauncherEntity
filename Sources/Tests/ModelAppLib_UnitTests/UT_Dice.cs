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
            Assert.Equal(2, d.SideTypes.Count);
            Assert.Equal(5, d.GetTotalSides());
        }

        [Theory]
        [MemberData(nameof(GetDatasForEquality))]
        public void EqualityComparerWorks(Object d1, Object d2, bool shouldItBeEqual)
        {
            if(d1 !=null)
                Assert.Equal(shouldItBeEqual, d1.Equals(d2));
            if(d2 != null)
                Assert.Equal(shouldItBeEqual, d2.Equals(d1));
        }

        [Theory]
        [MemberData(nameof(GetDatasForEquality))]
        public void HashCodesWork(Object d1, Object d2, bool shouldItHaveSameHash)
        {
            if(d1 != null && d2 != null)
            {
                Assert.Equal(shouldItHaveSameHash, d1.GetHashCode() == d2.GetHashCode());
            }
        }

        [Theory]
        [MemberData(nameof(GetDatasForNumberOfSides))]
        internal void CheckTotalNumberOfSides(Dice d, int theoricalNumberOfSides)
        {
            Assert.Equal(theoricalNumberOfSides, d.GetTotalSides());
        }

        [Theory]
        [MemberData(nameof(GetDatasForIndexesOfSides))]
        internal void CheckIndexOfSide(Dice d, int index, DiceSide ds)
        {
            Assert.True(d.GetSideWithItsIndex(index) == ds);
        }

        public static IEnumerable<object[]> GetDatasForIndexesOfSides()
        {
            DiceSide ds = new DiceSide("img");
            yield return new object[]
            {
                new Dice(
                    new DiceSideType(3, ds),
                    new DiceSideType(3, new DiceSide("img"))
                ),
                0,
                ds
            };

            DiceSide ds2 = new DiceSide("img2");
            yield return new object[]
            {
                new Dice(
                    new DiceSideType(3, ds2),
                    new DiceSideType(3, new DiceSide("img"))
                ),
                2,
                ds2
            };

            DiceSide ds3 = new DiceSide("img1");
            yield return new object[]
            {
                new Dice(
                    new DiceSideType(3, new DiceSide("img2")),
                    new DiceSideType(3, ds3)
                ),
                3,
                ds3
            };

            yield return new object[]
            {
                new Dice(
                    new DiceSideType(3, new DiceSide("img2")),
                    new DiceSideType(3, new DiceSide("img2"))
                ),
                6,
                null
            };

            yield return new object[]
            {
                new Dice(
                    new DiceSideType(3, new DiceSide("img2")),
                    new DiceSideType(3, new DiceSide("img2"))
                ),
                7,
                null
            };
        }

        public static IEnumerable<object[]> GetDatasForNumberOfSides()
        {
            yield return new object[]
            {
                new Dice(
                    new DiceSideType(3, new DiceSide("img")),
                    new DiceSideType(3, new DiceSide("img2"))
                ),
                6
            };
            
            yield return new object[]
            {
                new Dice(
                    new DiceSideType(2, new DiceSide("img2")),
                    new DiceSideType(3, new DiceSide("img2"))
                ),
                5
            };

            yield return new object[]
            {
                new Dice(
                    new DiceSideType(2, new DiceSide("img2")),
                    new DiceSideType(2, new DiceSide("img")),
                    new DiceSideType(3, new DiceSide("img2"))
                ),
                7
            };
        }

        public static IEnumerable<object[]> GetDatasForEquality()
        {
            yield return new object[]
            {
                new Dice(
                    new List<DiceSideType>{
                        new DiceSideType(1,new DiceSide("img1")),
                        new DiceSideType(1,new DiceSide("img1"))
                    } 
                ),
                new Dice(
                    new List<DiceSideType>{
                        new DiceSideType(2,new DiceSide("img1"))
                    }
                ),
                true
            };

            yield return new object[]
            {
                new Dice(
                    new List<DiceSideType>{
                        new DiceSideType(1,new DiceSide("img1")),
                        new DiceSideType(1,new DiceSide("img2"))
                    }
                ),
                new Dice(
                    new List<DiceSideType>{
                        new DiceSideType(2,new DiceSide("img1"))
                    }
                ),
                false
            };
            
            yield return new object[]
            {
                new Dice(
                    new List<DiceSideType>{
                        new DiceSideType(1,new DiceSide("img1")),
                        new DiceSideType(1,new DiceSide("img2"))
                    }
                ),
                new DiceSide("img"),
                false
            };
            
            yield return new object[]
            {
                new Dice(
                    new List<DiceSideType>{
                        new DiceSideType(1,new DiceSide("img1")),
                        new DiceSideType(1,new DiceSide("img2"))
                    }
                ),
                null,
                false
            };
        }

    }
}
