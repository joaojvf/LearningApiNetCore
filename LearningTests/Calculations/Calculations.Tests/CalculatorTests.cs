using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace Calculations.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void TestAdd()
        {
            Assert.True(true);
        }

        [Fact]
        public void Add_GivenTwoValues_ReturnsInt()
        {
            var calc = new Calculator();
            var result = calc.Add(1, 2);

            Assert.Equal(3, result);
        }

        [Fact]
        public void testColetion()
        {
            var calc = new Calculator();
            Assert.All(
                calc.FiboNumbers, n => Assert.NotEqual(0, n));
        }

        [Fact]
        public void FiboContais1()
        {
            var calc = new Calculator();
            Assert.Contains(1, calc.FiboNumbers);
        }

    }
}
