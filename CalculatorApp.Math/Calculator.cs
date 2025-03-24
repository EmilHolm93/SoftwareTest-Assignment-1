using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Calculator
    {
        public Calculator()
        {
            Accumulator = Double.NaN;
        }

        public double Accumulator { get; private set; }

        public double Add(double a, double b)
        {
            Accumulator = a + b;
            return Accumulator;
        }

        public double Subtract(double a, double b)
        {
            Accumulator = a - b;
            return Accumulator;
        }

        public double Multiply(double a, double b)
        {
            Accumulator = a * b;
            return Accumulator;
        }

        public double Power(double x, double exponent)
        {
            if (x < 0 && exponent % 1 != 0)
            {
                throw new ComplexPowerException(
                    "Raising a negative number to a fraction would result in a complex number!");
            }
            Accumulator = Math.Pow(x, exponent);

            return Accumulator;
        }

        public void Clear()
        {
            Accumulator = 0;
        }

        public double Add(double addend)
        {
            Accumulator = Accumulator + addend;
            return Accumulator;
        }

        public double Subtract(double subtractor)
        {
            Accumulator = Accumulator - subtractor;
            return Accumulator;
        }

        public double Multiply(double multiplier)
        {
            return Accumulator = Accumulator * multiplier;
        }


        public double Power(double exponent)
        {
            if (Accumulator < 0 && exponent % 1 != 0)
            {
                throw new ComplexPowerException(
                    "Raising a negative number to a fraction would result in a complex number!");
            }

            return Accumulator = Math.Pow(Accumulator, exponent);
        }


        public double Divide(double dividend, double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("Cannot divide by 0!");
            }
            Accumulator = dividend / divisor;
            return Accumulator;
        }

        public double Divide(double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("Cannot divide by 0!");
            }
            Accumulator /= divisor;
            return Accumulator;
        }

        public class ComplexPowerException : Exception
        {
            // Default constructor
            public ComplexPowerException() : base("An error occurred with complex power calculation.")
            {
            }

            // Constructor that allows a custom message
            public ComplexPowerException(string message) : base(message)
            {
            }

            // Constructor that allows a custom message and inner exception
            public ComplexPowerException(string message, Exception innerException)
                : base(message, innerException)
            {
            }
        }
    }
}

