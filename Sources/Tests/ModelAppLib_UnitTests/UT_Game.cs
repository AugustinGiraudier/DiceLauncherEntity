using System.Collections.Generic;
using System.Linq;
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
            Game gm = new Game(list);
            Assert.Equal(new List<DiceType>(), gm.Dices);
        }

        [Fact]
        public void TryAddDices()
        {
            List<DiceType> list = new List<DiceType>();
            Game gm = new Game(list);
            gm.AddDiceType(new DiceType(2, new Dice(new DiceSideType(3, new DiceSide("img1")))));
            gm.AddDiceType(new DiceType(5, new Dice(new DiceSideType(1, new DiceSide("img3")))));
            list.Add(new DiceType(2, new Dice(new DiceSideType(3, new DiceSide("img1")))));
            list.Add(new DiceType(5, new Dice(new DiceSideType(1, new DiceSide("img3")))));
            Assert.NotNull(gm.Dices);
            Assert.All(list, a => gm.Dices.Contains(a));
        }

        [Fact]
        public void TestLauncheDices()
        {
            Game game = new Game(
                new DiceType(3, new Dice(new DiceSideType(1, new DiceSide("img1"))))
            );
            List<DiceSide> list = game.LaunchDices();
            Assert.NotNull(list);
            Assert.Equal(3, list.Count);
        }

        public static IEnumerable<object[]> Data_AddDiceTypeToGame()
        {
            yield return new object[]
            {
                true,
                new DiceType[]
                {
                    new DiceType(1, new Dice(new DiceSideType(1, new DiceSide("img1")))),
                    new DiceType(2, new Dice(new DiceSideType(3, new DiceSide("img5")))),
                    new DiceType(3, new Dice(new DiceSideType(5, new DiceSide("img4")))),
                    new DiceType(1, new Dice(new DiceSideType(6, new DiceSide("img6")))),
                    new DiceType(4, new Dice(new DiceSideType(2, new DiceSide("img7")))),
                },
                new Game(new DiceType[]
                {
                    new DiceType(1, new Dice(new DiceSideType(1, new DiceSide("img1")))),
                    new DiceType(2, new Dice(new DiceSideType(3, new DiceSide("img5")))),
                    new DiceType(3, new Dice(new DiceSideType(5, new DiceSide("img4")))),
                    new DiceType(1, new Dice(new DiceSideType(6, new DiceSide("img6")))),
                }),
                new DiceType(4, new Dice(new DiceSideType(2, new DiceSide("img7"))))
            };
            yield return new object[]
            {
                false,
                new DiceType[]
                {
                    new DiceType(1, new Dice(new DiceSideType(1, new DiceSide("img1")))),
                    new DiceType(2, new Dice(new DiceSideType(3, new DiceSide("img5")))),
                    new DiceType(3, new Dice(new DiceSideType(5, new DiceSide("img4")))),
                    new DiceType(1, new Dice(new DiceSideType(6, new DiceSide("img6")))),
                },
                new Game(new DiceType[]
                {
                    new DiceType(1, new Dice(new DiceSideType(1, new DiceSide("img1")))),
                    new DiceType(2, new Dice(new DiceSideType(3, new DiceSide("img5")))),
                    new DiceType(3, new Dice(new DiceSideType(5, new DiceSide("img4")))),
                    new DiceType(1, new Dice(new DiceSideType(6, new DiceSide("img6")))),
                }),
                new DiceType(1, new Dice(new DiceSideType(6, new DiceSide("img6")))),
            };
        }

        [Theory]
        [MemberData(nameof(Data_AddDiceTypeToGame))]
        public void Test_AddDiceTypeToGame(bool expectResult, IEnumerable<DiceType> expectedDiceType, Game game, DiceType diceType)
        {
            bool result = game.AddDiceType(diceType);
            Assert.Equal(expectResult, result);
            var diceTypeTest = expectedDiceType.ToList();
            Assert.Equal(diceTypeTest.Count(), game.Dices.Count());
            Assert.All(diceTypeTest, e => game.Dices.Contains(e));
        }
    }