using Shopping_Spree.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Spree.Models
{
    class Person
    {
        private const string NOT_ENOGHT_MONEY_ERROR_MSG = "{0} can't afford {1}";
        private const string SUCC_BOUGHT_PRODUCT_MSG = "{0} bought {1}";

        private string name;
        private decimal money;
        private readonly ICollection<Product> bag;

        private Person()
        {
            bag = new List<Product>();
        }
        public Person(string name, decimal money) : this()
        {
            Name = name;
            Money = money;
        }

        public string Name 
        { 
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(GlobalConstants.INVALID_NAME_ERROR_MSG);
                }
                name = value;
            }
        }
        public decimal Money 
        { 
            get => money;
            private set
            {
                if (value < 0)
                {
                    throw new Exception(GlobalConstants.INVALID_MONEY_ERROR_MSG);
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag
        {
            get => (IReadOnlyCollection<Product>)this.bag;

        }

        public string BuyProduct(Product product)
        {
            if (product.Cost > Money)
            {
                return string.Format(NOT_ENOGHT_MONEY_ERROR_MSG, Name, product.Name);
            }
            else
            {
                bag.Add(product);
                Money -= product.Cost;
                return string.Format(SUCC_BOUGHT_PRODUCT_MSG, Name, product.Name);
            }
        }

        public override string ToString()
        {
            string result = this.Bag.Count > 0 ? string.Join(", ", Bag) : "Nothing bought";
            return $"{this.Name} - {result}";
        }
    }
}
