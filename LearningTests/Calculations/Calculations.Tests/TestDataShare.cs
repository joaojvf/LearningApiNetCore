using System;
using System.Collections.Generic;
using System.Text;

namespace Calculations.Tests
{
    public class TestDataShare
    {
        public static IEnumerable<object[]> IsOddOrEventData{
            get
            {
                yield return new object[] { 1, true };
                yield return new object[] { 200, false};

            }
        }
}
}
