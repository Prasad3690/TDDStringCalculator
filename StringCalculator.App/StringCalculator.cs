using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator.App
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var splitNumbers = numbers.Split(',');
            return splitNumbers.Sum(int.Parse);
        }
    }
}
