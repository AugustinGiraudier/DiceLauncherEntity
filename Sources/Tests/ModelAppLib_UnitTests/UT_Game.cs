using System;
using System.Collections.Generic;
using ModelAppLib;
using Xunit;

namespace ModelAppLib_UnitTests

    public class UT_Game
{
    [Fact]
    public void CreateObjectNotNull()
    {
        List<DiceType> lt = new List<DiceType>(
            new DiceSideType(2, sides[2]),
            new DiceSideType(3, sides[0])));
        );

        Game gm = new Game(lt);
        Assert.NotNull(gm);
    }
}