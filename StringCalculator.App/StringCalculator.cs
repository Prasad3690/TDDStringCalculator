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

            List<String> delimiters = new List<string>() { ",", "\n" };

            // Check for custom delimiter
            if (numbers.StartsWith("//"))
            {
                var parts = numbers.Split('\n');
                delimiters.Add(parts[0].Substring(2)); // Extract delimiter after "//"
                numbers = numbers.Substring(parts[0].Length + 1);
            }

            var splitNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.None);
            return splitNumbers.Select(int.Parse).Sum();
        }
    }
}
