using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Calculations.Tests
{
    public class CalculatorFixture
    {
        public Calculator Calc => new Calculator();
    }

    public class CalculatorTests : IClassFixture<CalculatorFixture>
    {
        private readonly CalculatorFixture _calculatorFixture;
        private readonly ITestOutputHelper _testOutpupHelper;
        private readonly MemoryStream memoryStream;
        public CalculatorTests(ITestOutputHelper testOutpupHelper, CalculatorFixture calculatorFixture)
        {
            _testOutpupHelper = testOutpupHelper;
            this._calculatorFixture = calculatorFixture;
            _testOutpupHelper.WriteLine("Construtor");

            memoryStream = new MemoryStream();

        }
        [Fact]
        public void TestAdd()
        {
            Assert.True(true);
        }

        [Fact]
        public void Add_GivenTwoValues_ReturnsInt()
        {
            var result = _calculatorFixture.Calc.Add(1, 2);

            Assert.Equal(3, result);
        }

        [Fact]
        public void testColetion()
        {
            Assert.All(
                _calculatorFixture.Calc.FiboNumbers, n => Assert.NotEqual(0, n));
        }

        [Fact]
        public void FiboContais1()
        {
            Assert.Contains(1, _calculatorFixture.Calc.FiboNumbers);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(200, false)]
        public void IsOdd_TestOddAndEven(int value, bool expected)
        {
            var res = _calculatorFixture.Calc.IsOdd(value);
            Assert.Equal(expected, res);
        }

    }
}
