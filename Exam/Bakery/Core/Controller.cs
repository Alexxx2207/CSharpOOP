using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        private decimal totalIncome;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
            totalIncome = 0m;
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;
            if (type == nameof(Tea))
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == nameof(Water))
            {
                drink = new Water(name, portion, brand);
            }

            if (drink == null)
            {
                throw new ArgumentNullException();

            }
            drinks.Add(drink);
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;
            if (type == nameof(Bread))
            {
                food = new Bread(name, price);
            }
            else if (type == nameof(Cake))
            {
                food = new Cake(name, price);
            }

            if (food == null)
            {
                throw new ArgumentNullException();
            }

            bakedFoods.Add(food);
            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;
            if (type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == nameof(OutsideTable))
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            if (table == null)
            {
                throw new ArgumentNullException();
            }
            tables.Add(table);
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> free = new List<ITable>();

            foreach (var table in tables)
            {
                if (!table.IsReserved)
                {
                    free.Add(table);
                }
            }

            StringBuilder sb = new StringBuilder();
            free.ForEach(t => sb.AppendLine(t.GetFreeTableInfo()));

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            StringBuilder sb = new StringBuilder();

            if (table != null)
            {
                sb.AppendLine($"Table: {tableNumber}");
                sb.AppendLine($"Bill: {table.GetBill():f2}");
                totalIncome += table.GetBill();
                table.Clear();
                return sb.ToString().TrimEnd();

            }
            else
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = drinks.FirstOrDefault(d => d.Brand == drinkBrand && d.Name == drinkName);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);
            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table1 = tables.FirstOrDefault(t => t.Capacity >= numberOfPeople && !t.IsReserved);

            if (table1 == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table1.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, table1.TableNumber, table1.NumberOfPeople);
        }
    }
}
