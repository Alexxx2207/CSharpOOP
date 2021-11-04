using NUnit.Framework;
using System;
using System.Linq;

public class DatabaseTests
{
    private Database database;
    [SetUp]
    public void Setup()
    {
        int[] numbers = Enumerable.Range(1, 16).ToArray();
        database = new Database(numbers);
    }

    [Test]
    public void CountCheck()
    {
        database = new Database();
        int countprev = database.Count;
        database.Add(1);
        int countAfter = database.Count;

        Assert.AreEqual(countprev, countAfter - 1);
    }

    [Test]
    public void DatabaseStores16()
    {
        Assert.IsTrue(database.Count == 16);
    }
    [Test]
    public void AddCheckerWrong()
    {
        Assert.Throws<InvalidOperationException>(() => database.Add(12));
    }
    [Test]
    public void RemoveCheckerWrong()
    {
        database = new Database();
        Assert.Throws<InvalidOperationException>(() => database.Remove());
    }
    [Test]
    public void AddChecker()
    {
        database = new Database();
        int countprev = database.Count;
        database.Add(12);
        int countExpected = 1;
        Assert.IsTrue(countprev == countExpected-1);
    }
    [Test]
    public void RemoveChecker()
    {
        database.Remove();
        CollectionAssert.AreEqual(database.Fetch(), Enumerable.Range(1, 15));
    }

    [Test]
    public void ConstructorChecker()
    {
        int[] numbers = database.Fetch();
        Assert.AreEqual(numbers[0].GetType(), typeof(int));
    }
    [Test]
    public void FetchChecker()
    {
        int[] numbers = database.Fetch();
        int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
        CollectionAssert.AreEqual(numbers, expected);
    }
    [TearDown]
    public void TearDown()
    {

    }
}