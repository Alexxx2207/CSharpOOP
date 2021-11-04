using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyTakesDmg()
    {
        Axe axe = new Axe(2, 100);
        Dummy dummy = new Dummy(2, 10);

        axe.Attack(dummy);

        Assert.IsTrue(dummy.IsDead());
    }

    [Test]
    public void DeadScreams()
    {
        Axe axe = new Axe(2, 100);
        Dummy dummy = new Dummy(0, 10);

        Assert.That(() => axe.Attack(dummy), 
            Throws.InvalidOperationException
            .With
            .Message
            .EqualTo("Dummy is dead."));
    }

    [Test]
    public void DeadDummyGivesExp()
    {
        Dummy dummy = new Dummy(0, 10);

        Assert.AreEqual(dummy.GiveExperience(), 10);
    }
    
    [Test]
    public void AliveDummyGivesExp()
    {
        Dummy dummy = new Dummy(1, 10);

        
        Assert.That(() => dummy.GiveExperience(),
            Throws
            .InvalidOperationException
            .With
            .Message.EqualTo("Target is not dead."));
    }
}
