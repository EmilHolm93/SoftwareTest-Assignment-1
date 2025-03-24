namespace CalculatorApp.Test.Unit
{
    internal class CalculatorUnitTests
    {
        private Calculator _uut;

        [SetUp]
        // Arrange
        public void Setup()
        {
            _uut = new Calculator();
        }

        [Test]
        public void Add_AddTwoPositiveNumbers_ReturnsCorrectSum()
        {
            // Act
            var result = _uut.Add(5, 3);

            // Assert
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Add_AddNegativeAndPositiveNumber_ReturnsCorrectSum()
        {
            // Act
            var result = _uut.Add(-5, 3);

            // Assert
            Assert.That(result, Is.EqualTo(-2));
        }

        [Test]
        public void Subtract_SubtractTwoPositiveNumbers_ReturnsCorrectDifference()
        {
            // Act
            var result = _uut.Subtract(9, 4);

            // Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Subtract_SubtractNegativeNumberFromPositive_ReturnsCorrectDifference()
        {
            // Act
            var result = _uut.Subtract(5, -3);

            // Assert
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Multiply_MultiplyTwoPositiveNumbers_ReturnsCorrectProduct()
        {
            // Act
            var result = _uut.Multiply(4, 3);

            // Assert
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void Multiply_MultiplyByZero_ReturnsZero()
        {
            // Act
            var result = _uut.Multiply(5, 0);

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Multiply_MultiplyPositiveByNegativeNumber_ReturnsNegativeProduct()
        {
            // Act
            var result = _uut.Multiply(5, -3);

            // Assert
            Assert.That(result, Is.EqualTo(-15));
        }

        [Test]
        public void Power_RaisePositiveNumberToPositiveExponent_ReturnsCorrectResult()
        {
            // Act
            var result = _uut.Power(2, 3);

            // Assert
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Power_RaiseNumberToZero_ReturnsOne()
        {
            // Act
            var result = _uut.Power(5, 0);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Power_RaiseNumberToNegativeExponent_ReturnsCorrectResult()
        {
            // Act
            var result = _uut.Power(2, -2);

            // Assert
            Assert.That(result, Is.EqualTo(0.25).Within(1e-9)); // Allow a small tolerance for floating-point operations
        }

        [Test]
        public void Power_RaiseNegativeNumberToEvenExponent_ReturnsPositiveResult()
        {
            // Act
            var result = _uut.Power(-2, 2);

            // Assert
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void Power_RaiseNegativeNumberToOddExponent_ReturnsNegativeResult()
        {
            // Act
            var result = _uut.Power(-2, 3);

            // Assert
            Assert.That(result, Is.EqualTo(-8));
        }


        [TestCase(2, 1, 2)]
        [TestCase(0, 1, 0)]
        [TestCase(2, -1, -2)]
        [TestCase(-2, -1, 2)]
        [TestCase(-2, -1, 2)]
        public void Divide_DivisionOfTwoWholeNumber_ReturnsCorrectResult(double dividend, double divisor,
            double expectedResult)
        {
            //Arrange

            //Act
            var result = _uut.Divide(dividend, divisor);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(10, 5, 2)]
        [TestCase(0, 1, 0)]
        [TestCase(2, -1, -2)]
        [TestCase(-2, -1, 2)]
        [TestCase(-2, -1, 2)]
        public void DivideAccumulator_DivisionOfWholeNumberAndAccumulator_ReturnsCorrectResult(double initialVal, double divisor,
            double expectedResult)
        {
            //Arrange
            _uut.Add(0, initialVal);

            //Act
            var result = _uut.Divide(divisor);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Accumulator_InitialState_IsNaN()
        {
            Assert.IsTrue(double.IsNaN(_uut.Accumulator));
        }


        [TestCase(2, 3, 8)]      // 2^3 = 8
        [TestCase(2, -2, 0.25)]  // 2^(-2) = 0.25
        [TestCase(-3, 2, 9)]     // (-3)^2 = 9
        [TestCase(-3, 3, -27)]   // (-3)^3 = -27
        public void Power_AccumulatorWithPositiveAndNegativeExponents_ReturnsCorrectResult(double initialValue, double exponent,
            double expectedResult)
        {
            // Arrange
            _uut.Clear();
            _uut.Add(initialValue); // Set Accumulator

            // Act
            var result = _uut.Power(exponent);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(10, 3, 30)]
        [TestCase(57, 0, 0)]
        [TestCase(23, -0.5, -11.5)]
        [TestCase(-4, -4, 16)]
        [TestCase(0, 0, 0)]
        public void Multiply_AccumulatedMultipliedByMultiplier_ReturnsCorrectResult(double initialValue, double multiplier, double expectedResult)
        {
            //Arrange
            _uut.Add(0, initialValue);

            //Act
            var result = _uut.Multiply(multiplier);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}