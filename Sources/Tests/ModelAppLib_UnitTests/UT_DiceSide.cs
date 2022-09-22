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

    }
}
