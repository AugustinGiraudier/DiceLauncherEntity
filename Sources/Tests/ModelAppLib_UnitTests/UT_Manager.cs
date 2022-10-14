using System;
using System.Collections.Generic;
using System.Linq;
using ModelAppLib;
using StubLib;
using Xunit;

namespace ModelAppLib_UnitTests;

public class UT_Manager
{

    /// <summary>
    ///
    /// Faire un stub de test pour stocker toute les données à tester
    /// Faire des memberDate pour tester les fonctions d'ajouts
    /// Tester si ca l'ajoute bien, quand on essaye d'ajouter un truc null, d'ajouter
    /// un truc qui à déjà été ajouter, l'état du dataManager si jamais il en a un
    ///
    /// </summary>
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
    async void AddDiceNull()
    {
        ModelManager manager = new ModelManager(new Stub());
        Dice newDe = null;
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.AddDice(newDe));
    }

    public static IEnumerable<object[]> DataAddDiceModele()
    {
        
        yield return new object[]
        {
            null,
            null,
            StubForUT.getDiceWithValue(),
            StubForUT.getGameWithValue()
        };
    }

    [Theory]
    [MemberData(nameof(DataAddDiceModele))]
    public async void TestAddDiceNull(Dice diceNull, Game gmNull, Dice __, Game ___)
    {
        ModelManager modele = new ModelManager(new Stub());
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await modele.AddDice(diceNull));
        await Assert.ThrowsAsync<ArgumentNullException>(async () => await modele.AddGame(gmNull));
    }
}