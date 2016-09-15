using FluentAssertions;
using NUnit.Framework;

namespace MB.Softcrafts.DesignPattern.Strategy.Test
{
    [TestFixture]
    public class StrategyTests
    {
        [Test]
        public void AdditionTest()
        {
            //arrange
            var calc = new Calculator(new Addition());
            //act
            var sut = calc.Calculate(5, 4);
            //assert
            sut.Should().Be(9);
        }

        [Test]
        public void SubtractTest()
        {
            //arrange
            var calc = new Calculator(new Subtract());
            //act
            var sut = calc.Calculate(-5, 4);
            //assert
            sut.Should().Be(-9);
        }

        [Test]
        public void MultiplicationTest()
        {
            //arrange
            var calc = new Calculator(new Multiplication());
            //act
            var sut = calc.Calculate(5, 4);
            //assert
            sut.Should().Be(20);
        }

        [Test]
        public void DivisionTest()
        {
            //arrange
            var calc = new Calculator(new Division());
            //act
            var sut = calc.Calculate(-6, 2);
            //assert
            sut.Should().Be(-3);
        }
    }
}