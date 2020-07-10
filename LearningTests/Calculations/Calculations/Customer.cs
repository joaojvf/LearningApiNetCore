using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations
{
    public class Customer
    {
        public string Name => "Joao";
        public int Age => 23;

        public virtual int GetOrdersByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException();
            }

            return 100;
        }
    }

    public class LoayalCustomer : Customer
    {
        public int Discount { get; set; }
        public LoayalCustomer()
        {
            Discount = 10;
        }

        public override int GetOrdersByName(string name)
        {
            return 101;
        }
    }

    public static class CustomerFactory
    {
        public static Customer CreateCustomer(int orderCount)
        {
            if (orderCount <= 100)
                return new Customer();
            else
                return new LoayalCustomer();
        }
    }
}
