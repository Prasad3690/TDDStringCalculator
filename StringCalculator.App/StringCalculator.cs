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
        private int callCount = 0;

        public event Action<string, int> AddOccured; // Event declaration

        public int Add(string numbers)
        {
            callCount++;

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

            var splitNumbers = numbers.Split(delimiters.ToArray(), StringSplitOptions.None)
                                   .Select(int.Parse)
                                   .Where(n => n <= 1000)
                                   .ToList();

            var negatives = splitNumbers.Where(n => n < 0).ToList();
            if (negatives.Any())
            {
                throw new ArgumentException($"negatives not allowed: {string.Join(", ", negatives)}");
            }

            int sum = splitNumbers.Sum();

            // Trigger event after Add() executes
            AddOccured?.Invoke(numbers, sum);

            return sum;
        }

        public int GetCalledCount()
        {
            return callCount;
        }
    }
}
