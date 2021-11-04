using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorTest()
        {
            BankVault bv = new BankVault();

            Assert.IsNotNull(bv);
        }
        [Test]
        public void VaultCellsIReadOnlyDictionaryTest()
        {
            BankVault bv = new BankVault();
            bv.AddItem("B4", new Item("sa", "12"));
            IReadOnlyDictionary < string, Item > test = bv.VaultCells;
            Assert.AreEqual(bv.VaultCells.Count, test.Count);
        }
        [Test]
        public void AddCellsDoesntExistTest()
        {
            BankVault bv = new BankVault();
           
            Assert.Throws<ArgumentException>(() => bv.AddItem("cc", new Item("sa", "12")));
        }
        [Test]
        public void AddCellAlreadyTakenTest()
        {
            BankVault bv = new BankVault();
            bv.AddItem("C4", new Item("sa", "12"));
            Assert.Throws<ArgumentException>(() => bv.AddItem("C4", new Item("sa", "12")));
        }
        [Test]
        public void AddSameItemTest()
        {
            BankVault bv = new BankVault();
            bv.AddItem("C4", new Item("sa", "12"));
            Assert.Throws<InvalidOperationException>(() => bv.AddItem("C1", new Item("sa", "12")));
        }
        [Test]
        public void RemoveCellsDoesntExistTest()
        {
            BankVault bv = new BankVault();
           
            Assert.Throws<ArgumentException>(() => bv.RemoveItem("cc", new Item("sa", "12")));
        }
        [Test]
        public void RemoveCellWithoutThisItemTest()
        {
            BankVault bv = new BankVault();
            Item a = new Item("sa", "12");

            Assert.Throws<ArgumentException>(() => bv.RemoveItem("C4", a));
        }
        [Test]
        public void RemoveCorrectlyest()
        {
            BankVault bv = new BankVault();
            Item a = new Item("sa", "12");

            bv.AddItem("C4", a);
            bv.RemoveItem("C4", a);
            Assert.AreEqual(bv.VaultCells["C4"], null);
        }
    }
}