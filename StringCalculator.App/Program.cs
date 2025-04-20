using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalculatorClass = StringCalculator.App.StringCalculator;

namespace StringCalculator.App
{
    internal class Program
    {
        private static StringCalculatorClass _calculator;

        static void Main(string[] args)
        {
            _calculator = new StringCalculatorClass();
            Console.ReadKey();
        }
    }
}
