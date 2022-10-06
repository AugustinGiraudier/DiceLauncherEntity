using System;
using System.Collections.Generic;
using ModelAppLib;
using StubLib;
using Xunit;

namespace ModelAppLib_UnitTests;

public class UT_Manager
{
    
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
        Assert.NotNull(modele.GetAllDices().Contains(newDe));
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
}