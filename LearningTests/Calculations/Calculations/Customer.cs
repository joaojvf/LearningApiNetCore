using System;

namespace Calculations
{
    public class Customer: IDisposable
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

        #region [Disposable]        
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
                return;

            if (disposing)
            {

            }

            disposedValue = true;
        }

        ~Customer()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion [Disposable]
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
