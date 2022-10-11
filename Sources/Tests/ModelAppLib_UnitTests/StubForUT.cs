using System.Collections.Generic;
using ModelAppLib;

namespace ModelAppLib_UnitTests;

public class StubForUT
{
    public Dice getDiceNull()
    {
        return null; 
    }

    public Dice getDiceWithValue()
    {
        return new Dice(new DiceSideType(1, new DiceSide("1.png")),
            new DiceSideType(2, new DiceSide("1.png")),
            new DiceSideType(3, new DiceSide("1.png")));
    }

    public Game getGameNull()
    {
        return null;
    }

    public Game getGameWithValue()
    {
        return new Game(new DiceType[]
        {
            new DiceType(1, new Dice(new DiceSideType(1, new DiceSide("img1")))),
            new DiceType(2, new Dice(new DiceSideType(2, new DiceSide("img2")))),
            new DiceType(3, new Dice(new DiceSideType(3, new DiceSide("img3"))))
        });
    }
}