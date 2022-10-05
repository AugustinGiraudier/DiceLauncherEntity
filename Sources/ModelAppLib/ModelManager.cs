using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ModelAppLib
{
    public class ModelManager
    {

        private DiceStorage diceStorage = new DiceStorage(null, null);
        private List<Game> games = new List<Game>();

        public void AddDice(Dice d) 
        {
            diceStorage.AddDice(d);
        }
        public void AddGame(Game g)
        {
            if(g != null)
                games.Add(g);
        }

        public int GetDiceCount() { return diceStorage.Dices.Count; }
        public int GetSideCount() { return diceStorage.Sides.Count; }
        public int GetGameCount() { return games.Count; }

        public ReadOnlyCollection<DiceSide> GetAllSides() { return diceStorage.Sides; }
        
        public ReadOnlyCollection<Dice> GetAllDices() { return diceStorage.Dices; }

        public ReadOnlyCollection<Game> GetAllGames() { return games.AsReadOnly(); }

        public void InitDices(List<Dice> ld) 
        {
            diceStorage.InitDices(ld);
        }

        public void InitSides(List<DiceSide> lds)
        {
            diceStorage.InitSides(lds);
        }

        public void InitGames(List<Game> lg)
        {
            if (lg == null) return;
            lg.Clear();
            foreach(Game g in lg)
            {
                games.Add(g);
            }
        }

    }
}
