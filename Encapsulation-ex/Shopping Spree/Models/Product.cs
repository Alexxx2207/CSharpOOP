using System;
using Shopping_Spree.Common;

namespace Shopping_Spree.Models
{
    class Product
    {
       
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name 
        { 
          get => this.name; 

            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(GlobalConstants.INVALID_NAME_ERROR_MSG);
                }
                name = value;
            }
        }

        public decimal Cost 
        { 
            get => this.cost; 
            
            private set 
            {
                if (value <= 0)
                {
                    throw new Exception(GlobalConstants.INVALID_MONEY_ERROR_MSG);
                }

                cost = value;
            }
        }
        public override string ToString()
        {
            return this.Name;
        }
    }
}
