using System;

namespace Calculations.UnitTests
{
    public class CustomerFixtures : IDisposable
    {
        public Customer Customer { get; }

        public CustomerFixtures()
        {
            Customer = new Customer();
        }

        #region [Disposable]        
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (disposedValue)
                return;

            if (disposing)
            {
                Customer.Dispose();
            }

            disposedValue = true;
        }

        ~CustomerFixtures()
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
}
