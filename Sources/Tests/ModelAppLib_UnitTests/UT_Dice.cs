using System;
using System.Collections.Generic;
using ModelAppLib;
using Xunit;

namespace ModelAppLib_UnitTests
{
    public class UT_Dice
    {
        [Fact]
        public void Creat()
        {
            DiceSide ds = new("/img/1.png");
            DiceSideType dst = new(3, ds);
            var lst = new List<DiceSideType>();
            lst.Add(dst);
            Dice d = new(lst);


            Assert.NotNull(d);
            Assert.Single(d.GetSideTypes);

            d.addSide(dst);
            Assert.Single(d.GetSideTypes);

            Assert.Equal(6, d.GetSideTypes[0].NbSide);

            DiceSideType dst2 = new(2, ds);
            d.addSide(dst2);
            Assert.Single(d.GetSideTypes);

            DiceSide ds2 = new("/img/2.png");
            DiceSideType dst3 = new(2, ds2);
            d.addSide(dst3);
            Assert.Equal(2, d.GetSideTypes.Count);
        }
    }
}
