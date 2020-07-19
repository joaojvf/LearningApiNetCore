using FluentAssertions;
using System;
using Xunit;

namespace Calculations.UnitTests
{
    [Trait(@"Class", @"Calculations.Names")]
    public class NameTests
    {
        [Fact]
        public void MakeFullNameText()
        {
            var names = new Names();
            var res = names.MakeFullName("Joao", "Ferreira");
            Assert.Equal("joao Ferreira", res, ignoreCase: true);
        }

        [Fact]
        public void MakeFullNameTextContains()
        {
            var names = new Names();
            var res = names.MakeFullName("Joao", "Ferreira");
            Assert.Contains("joao", res, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void MakeFullNameTextEndsWith()
        {
            var names = new Names();
            var res = names.MakeFullName("Joao", "Ferreira");
            Assert.EndsWith("eira", res, StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void NickName_MustBeNull()
        {
            var names = new Names();
            Assert.Null(names.NickName);
        }


        [Fact]
        public void NickName_AlwaysReturnValue()
        {
            var names = new Names();
            names.NickName = "XXX";
            Assert.NotNull(names.NickName);
        }
    }
}
