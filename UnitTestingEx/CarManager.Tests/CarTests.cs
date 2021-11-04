using NUnit.Framework;
using System;

public class CarTests
{
    private Car car;
    [SetUp]
    public void Setup()
    {
        car = new Car("audi","R8", 5, 300);
    }

    [Test]
    public void CarConstructorTest()
    {
        Assert.IsTrue(car.FuelAmount == 0);
        Assert.IsTrue(car.Make == "audi");
        Assert.IsTrue(car.Model == "R8");
        Assert.IsTrue(car.FuelConsumption == 5);
        Assert.IsTrue(car.FuelCapacity == 300);
    }
    [Test]
    public void TestMakeError()
    {
        string make = null;

        Assert.Throws<ArgumentException>(() => car = new Car(make ,"R8", 5, 300));
    }
    [Test]
    public void TestModelError()
    {
        string model = null;

        Assert.Throws<ArgumentException>(() => car = new Car("audi" ,model, 5, 300));
    }
    [Test]
    [TestCase(0)]
    [TestCase(-1)]
    public void TestFuelConsumptionError(double fuelConsump)
    {
        Assert.Throws<ArgumentException>(() => car = new Car("audi" ,"R8", fuelConsump, 300));
    }
    [Test]
    [TestCase(0)]
    [TestCase(-1)]
    public void TestFuelCapacityError(double fuleCapa)
    {
        Assert.Throws<ArgumentException>(() => car = new Car("audi", "R8", 5, fuleCapa));
    }

    [Test]
    [TestCase(0)]
    [TestCase(-1)]
    public void TestFuelToRefuelError(int fuel)
    {
        Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
    }
    [Test]
    [TestCase(100)]
    public void TestFuelToRefuelActuallyRefuel(int fuel)
    {
        double carFuel = car.FuelAmount;
        car.Refuel(fuel);
        Assert.IsTrue(car.FuelAmount == 100);
    }
    [Test]
    [TestCase(1000)]
    public void TestFuelToRefuelActuallyRefuelExceeded(int fuel)
    {
        double carFuel = car.FuelAmount;
        car.Refuel(fuel);
        Assert.IsTrue(car.FuelAmount == car.FuelCapacity);
    }
    
    [Test]
    [TestCase(1000)]
    public void TestFuelNeededError(double dis)
    {
        double carFuel = car.FuelAmount;
        Assert.Throws<InvalidOperationException>(() => car.Drive(dis));

    }
    [Test]
    [TestCase(100)]
    public void TestFuelIsUsedProperly(double dis)
    {
        car.Refuel(10);
        double carFuel = car.FuelAmount;
        car.Drive(dis);
        Assert.IsTrue(car.FuelAmount == 5);

    }
}