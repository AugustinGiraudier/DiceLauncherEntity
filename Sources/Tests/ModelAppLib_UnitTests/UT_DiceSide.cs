using System;
using System.Collections.Generic;
using ModelAppLib;
using Xunit;

namespace ModelAppLib_UnitTests
{
    public class UT_DiceSide
    {

        [Fact]
        public void CreateObjectNotNull()
        {
            DiceSide ds = new("img");
            Assert.NotNull(ds);
        }

        [Fact]
        public void CanGetImage()
        {
            DiceSide ds = new("imagePath");
            Assert.Equal("imagePath", ds.Image);
        }

        [Theory]
        [InlineData("img1","img2", false)]
        [InlineData("img1","img1", true)]
        [InlineData("test test","test test", true)]
        [InlineData("","", true)]
        [InlineData(""," ", false)]
        public void EqualityComprarerWorks(String img1, String img2, bool shouldItBeEqual)
        {
            DiceSide ds = new(img1);
            DiceSide ds2 = new(img2);

            Assert.Equal(shouldItBeEqual, ds.Equals(ds2));
            Assert.Equal(shouldItBeEqual, ds2.Equals(ds));
        }

    }
}
