using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ArenaTests
{
    private Arena arena;
    private Warrior warrior;

    [SetUp]
    public void Setup()
    {
        arena = new Arena();
        warrior = new Warrior("Alex", 100, 100);
    }

    [Test]
    public void TestArenaConstructor()
    {
        Assert.IsTrue(arena.Warriors != null);
    }
    
    [Test]
    public void TestArenaCount()
    {
        arena.Enroll(warrior);
        Assert.IsTrue(arena.Count == 1);
    }
    
    [Test]
    public void TestArenaEnrollError()
    {
        arena.Enroll(warrior);
        Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
    }

    [Test]
    [TestCase("Alex", "Gosho")]
    public void TestNullWarrior2(string warriorName1, string warriorName2)
    {
        arena.Enroll(warrior);
        Assert.Throws<InvalidOperationException>(() => arena.Fight(warriorName1, warriorName2));
    }
    
    [Test]
    [TestCase("Alex", "Gosho")]
    public void TestNullWarrior1(string warriorName1, string warriorName2)
    {
        arena.Enroll(new Warrior("Gosho", 100, 50));
        Assert.Throws<InvalidOperationException>(() => arena.Fight(warriorName1, warriorName2));
    }
    [Test]
    [TestCase("Alex", "Gosho")]
    public void TestWarriorActuallyFight(string warriorName1, string warriorName2)
    {
        arena.Enroll(warrior);
        Warrior warrior2 = new Warrior("Gosho", 50, 150);
        arena.Enroll(warrior2);

        Warrior attacker = ((List<Warrior>)arena.Warriors).First(w => w.Name == warriorName1);
        Warrior defender = ((List<Warrior>)arena.Warriors).First(w => w.Name == warriorName2);

        arena.Fight(warriorName1, warriorName2);

        Assert.IsTrue(warrior.HP == 50);
        Assert.IsTrue(warrior2.HP == 50);
    }
}