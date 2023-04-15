using System;
using Xunit;
using Domain;
using FluentAssertions;

namespace CalculatorTest

{
    public class CalculatorTests
    {
        [Fact]
        public void Sum_of_2_and_2_should_be_4() => new Calculator().Sum(2, 2).Should().Be(4);
        public void Sum_of_1_and_3_should_be_4() => new Calculator().Sum(1, 3).Should().Be(4);
        public void Sum_of_3_and_3_should_be_6() => new Calculator().Sum(3, 3).Should().Be(6);
    }
}