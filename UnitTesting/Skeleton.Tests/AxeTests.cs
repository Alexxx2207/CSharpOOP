
using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    [Test]
    public void TestDurability()
    {
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(10, 10);
        // Act
        axe.Attack(dummy);
        // Assert
        Assert.That(axe.DurabilityPoints, Is.EqualTo(9));

    }

    [Test]
    public void TestBroken()
    {
        Axe axe = new Axe(1, 1);
        Dummy dummy = new Dummy(10, 10);

        axe.Attack(dummy);

        Assert.That(() => axe.Attack(dummy),
          Throws.InvalidOperationException
            .With.Message.EqualTo("Axe is broken."));
    }

}