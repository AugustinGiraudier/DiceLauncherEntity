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
    }
}
