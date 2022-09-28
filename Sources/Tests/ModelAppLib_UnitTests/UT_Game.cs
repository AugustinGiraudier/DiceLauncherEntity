using System;
using System.Collections.Generic;
using ModelAppLib;
using Xunit;

namespace ModelAppLib_UnitTests;

    public class UT_Game
    {
        [Fact]
        public void CreateObjectNotNull()
        {
            Game gm = new Game(new List<DiceType>());
            Assert.NotNull(gm);
        }

        
    }