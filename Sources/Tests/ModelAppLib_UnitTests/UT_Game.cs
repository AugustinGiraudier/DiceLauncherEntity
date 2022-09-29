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

        [Fact]
        public void GetList()
        {
            List<DiceType> list = new List<DiceType>();
            //Dice d = new(new DiceSideType(3, new DiceSide("img1")));
            
            Game gm = new Game(list);
            Assert.Equal(new List<DiceType>(), gm.Dices);
        }

        [Fact]
        public void TryAddDices()
        {
            List<DiceType> list = new List<DiceType>();
            Game gm = new Game(list);
            gm.AddDiceType(new DiceType(2, new Dice(new DiceSideType(3, new DiceSide("img1")))));
            Assert.NotNull(gm.Dices);
            Assert.Equal(list[0], gm.Dices[0]);
        }

        
    }