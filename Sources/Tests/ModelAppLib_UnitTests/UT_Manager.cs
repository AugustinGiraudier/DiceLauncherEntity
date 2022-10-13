using System;
using System.Collections.Generic;
using System.Linq;
using ModelAppLib;
using StubLib;
using Xunit;

namespace ModelAppLib_UnitTests;

public class UT_Manager
{
    private static StubForUT stubUT = new StubForUT();
    
    /**
     * Faire un stub de test pour stocker toute les données à tester
     * Faire des memberDate pour tester les fonctions d'ajouts
     * Tester si ca l'ajoute bien, quand on essaye d'ajouter un truc null, d'ajouter
     * un truc qui à déjà été ajouter, l'état du dataManager si jamais il en a un
     */
    [Fact]
    void CreateObjectNotNull()
    {
        IDataManager manager = new Stub();
        ModelManager modele = new ModelManager(manager);
        Assert.NotNull(modele);
    }

    [Fact]
    void CreateObjectNull()
    {
        IDataManager manager = null;
        Assert.Throws<ArgumentNullException>(() => new ModelManager(manager));
    }

    [Fact]
    void AddDiceNotNull()
    {
        ModelManager modele = new ModelManager(new Stub());
        Dice newDe = new Dice(
            new DiceSideType(2, new DiceSide("img2")),
            new DiceSideType(3, new DiceSide("img2")));
        modele.AddDice(newDe);
        var dices = modele.GetAllDices().ToList();
        Assert.NotNull(dices.Contains(newDe));
    }

    [Fact]
    void AddDiceNull()
    {
        ModelManager manager = new ModelManager(new Stub());
        Dice newDe = null;
        Assert.Throws<ArgumentNullException>(() => manager.AddDice(newDe));
    }

    [Fact]
    void AddGameNotNull()
    {
        ModelManager manager = new ModelManager(new Stub());
        List<DiceType> list = new List<DiceType>
        {
            new DiceType(1, new Dice(
                new DiceSideType(2, new DiceSide("img2")),
                new DiceSideType(3, new DiceSide("img2"))))
        };
        Game gm = new Game(list);
        manager.AddGame(gm);
        Assert.NotNull(manager.GetAllGames().Contains(gm));
        //Assert.Equal(gm, manager.GetAllGames().Contains(gm));
    }

    public static IEnumerable<object[]> DataAddDiceModele()
    {
        
        yield return new object[]
        {
            stubUT.getDiceNull(),
            stubUT.getGameNull(),
            stubUT.getDiceWithValue(),
            stubUT.getGameWithValue()
        };
    }

    [Theory]
    [MemberData(nameof(DataAddDiceModele))]
    public void Test_AddDiceNull(Dice diceNull, Game gmNull, Dice diceValue, Game gmValue)
    {
        ModelManager modele = new ModelManager(new Stub());
        Assert.Throws<ArgumentNullException>(() => modele.AddDice(diceNull));
        //Assert.True(modele.AddDice(diceValue));
        //Assert.Contains(diceValue, modele.GetAllDices()); A faire quand la méthode ajoutera vraiment
        Assert.Throws<ArgumentNullException>(() => modele.AddGame(gmNull));
        //Assert.True(modele.AddGame(gmValue));
        //Assert.Contains(gmValue, modele.GetAllGames()); A faire quand la méthode ajoutera vraiment
    }
}