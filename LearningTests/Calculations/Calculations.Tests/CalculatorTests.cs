using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Calculations.UnitTests
{
    public class CalculatorFixture
    {
        public Calculator Calc => new Calculator();
    }

    [Trait(@"Class", @"Calculations.Calculator")]
    public class CalculatorTests : IClassFixture<CalculatorFixture>
    {
        private readonly CalculatorFixture _calculatorFixture;
        private readonly ITestOutputHelper _testOutpupHelper;

        public CalculatorTests(ITestOutputHelper testOutpupHelper, CalculatorFixture calculatorFixture)
        {
            _testOutpupHelper = testOutpupHelper;
            _calculatorFixture = calculatorFixture;
            _testOutpupHelper.WriteLine("Construtor");
        }

        [Trait(@"Method", @"Calculations.Calculator.Add")]
        [Theory(DisplayName = @"Add - Given two values, I hope to receive the sum between them")]
        [InlineData(1, 1, 2)]
        [InlineData(1, 2, 3)]
        [InlineData(2, 1, 3)]
        [InlineData(2, 2, 4)]
        [InlineData(100, 100, 200)]
        [InlineData(100, 200, 300)]
        [InlineData(200, 100, 300)]
        [InlineData(-1, 1, 0)]
        [InlineData(-2, 1, -1)]
        [InlineData(-10, 20, 10)]
        public void Add_GivenTwoValues_ReturnsInt(int number1, int number2, int expected)
        {
            var result = _calculatorFixture.Calc.Add(number1, number2);
            result.Should().Be(expected);
        }

        [Trait(@"Property", @"Calculations.Calculator.FiboNumbers")]
        [Fact(DisplayName = @"FiboNumbers - Given the fibonacci dataset, I expect a non-null, non-empty list and all elements greater than zero")]
        public void testColetion()
        {
            _calculatorFixture.Calc.FiboNumbers
                .Should().NotBeNull()
                .And.NotBeEmpty()
                .And.NotContain(fn => fn <= 0);
        }

        [Trait(@"Property", @"Calculations.Calculator.FiboNumbers")]
        [Fact(DisplayName = @"FiboNumbers - Given the fibonacci data set, I expect a non-null, non-empty list containing the values 1,2,3,5")]
        public void FiboContais1()
        {
            _calculatorFixture.Calc.FiboNumbers
                .Should().NotBeNull()
                .And.NotBeEmpty()
                .And.Contain(new[] { 1, 2, 3, 5 });
        }

        [Trait(@"Method", @"Calculations.Calculator.IsOdd")]
        [Theory(DisplayName = @"IsOdd - Given any number, I expect to receive if it is odd or not")]
        [MemberData(nameof(TestDataShare.IsOddOrEventData), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddAndEven(int value, bool expected)
        {
            var res = _calculatorFixture.Calc.IsOdd(value);
            res.Should().Be(expected);
        }

    }
}
