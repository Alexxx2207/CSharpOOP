using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int capacity;
        private int numberofPeople;
        private List<IBakedFood> FoodOrders;
        private List<IDrink> DrinkOrders;
        private bool isResereved;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            FoodOrders = new List<IBakedFood>();
            DrinkOrders = new List<IDrink>();
            isResereved = false;
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }

        public int TableNumber { get; private set; }
        public int Capacity
        {
            get => capacity;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }
        public int NumberOfPeople
        {
            get => numberofPeople;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                numberofPeople = value;
            }
        }
        public decimal PricePerPerson { get; private set; }
        public bool IsReserved => isResereved;

        public decimal Price 
        {
            get => NumberOfPeople * PricePerPerson;
        }

        public void Clear()
        {
            isResereved = false;
            numberofPeople = 0;
            FoodOrders = new List<IBakedFood>();
            DrinkOrders = new List<IDrink>();
            PricePerPerson = 0;
        }

        public decimal GetBill()
        {
            return CalcPrice();
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            DrinkOrders.Add(drink);
        }
        public void OrderFood(IBakedFood food)
        {
            FoodOrders.Add(food);
        }
        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            isResereved = true;
            
        }

        private decimal CalcPrice()
        {
            decimal result = Price;
            foreach (var food in FoodOrders)
            {
                if (food != null)
                {
                    result += food.Price; 
                }
            }
            foreach (var drink in DrinkOrders)
            {
                if (drink != null)
                {
                    result += drink.Price; 
                }
            }

            return result;
        }
    }
}
